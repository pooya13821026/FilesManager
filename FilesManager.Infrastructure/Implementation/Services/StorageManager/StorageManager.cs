using FilesManager.Application.Common.Validations;
using FilesManager.Application.Contracts.Services;
using FilesManager.Application.Models.DTOs.StorageManager;
using FilesManager.Domain.Entities.File;
using FilesManager.Infrastructure.Data;
using FilesManager.Infrastructure.Implementation.Repositories.StorageManager;
using FilesManager.Infrastructure.Implementation.Services.StorageManager.Utils;
using FluentValidation.Results;


namespace FilesManager.Infrastructure.Implementation.Services.StorageManager;

public class StorageManager : IStorageManager
{
    private readonly StorageManagerRepository _storageManagerRepository;
    private readonly ApplicationContext _dbContext;
    private readonly string _compressedFolderPath;
    private readonly string _temporaryFolderPath;
    private readonly int _passwordGeneratorLength;

    public StorageManager(StorageManagerRepository storageManagerRepository, ApplicationContext dbContext)
    {
        _storageManagerRepository = storageManagerRepository;
        _dbContext = dbContext;
        _compressedFolderPath = Path.Combine(/*_dbContext.RootPath*/ "compressed");
        _temporaryFolderPath = Path.Combine(/*_dbContext.RootPath,*/ "temporary");
        _passwordGeneratorLength = 10;
    }

    public async Task<string> SaveStorageFile(Storage_Manager_Dto dto)
    {
        // validation
        StorageFileValidator validator = new();
        ValidationResult validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            foreach (ValidationFailure? err in validationResult.Errors)
            {
                Console.WriteLine($"Error : {err.PropertyName} - {err.ErrorMessage} - {err.ErrorCode}");
                throw new Exception();
            }
        }

        // Create the required folders if they do not exist
        CreateDirectories(_compressedFolderPath, _temporaryFolderPath);

        if (dto.Id != null)
        {
            var fileData = await _dbContext.File.FindAsync(dto.Id);
            if (fileData != null)
            {
                UpdateFileData(dto, fileData);
                _storageManagerRepository.Add();
                await _storageManagerRepository.CommitAsync();

                return await SaveOrUpdateCompressedFile(dto, fileData);
            }
        }
        return await SaveNewCompressedFile(dto);
    }


    private async Task<string> SaveOrUpdateCompressedFile(Storage_Manager_Dto dto, AppFile fileData)
    {
        using (var stream = dto.File.OpenReadStream())
        {
            string temporaryFilePath = Path.Combine(_temporaryFolderPath, dto.OriginalFileName);

            await using (var fileStream = File.Create(temporaryFilePath))
            {
                await stream.CopyToAsync(fileStream);
            }

            return await ProcessCompressedFile(dto, temporaryFilePath, fileData);
        }
    }

    private async Task<string> SaveNewCompressedFile(Storage_Manager_Dto dto)
    {
        using (var stream = dto.File.OpenReadStream())
        {
            string temporaryFilePath = Path.Combine(_temporaryFolderPath, dto.OriginalFileName);

            await using (var fileStream = File.Create(temporaryFilePath))
            {
                await stream.CopyToAsync(fileStream);
            }

            var fileData = new AppFile
            {
                Title = dto.OriginalFileName,
                Description = dto.Description,
                Version = 1,
                IsPublic = true
            };

            _storageManagerRepository.Add(fileData);
            await _storageManagerRepository.CommitAsync();

            return await ProcessCompressedFile(dto, temporaryFilePath, fileData);
        }
    }

    private async Task<string> ProcessCompressedFile(Storage_Manager_Dto dto, string temporaryFilePath, AppFile fileData)
    {
        if (dto.IsCompressFile)
        {
            string compressedFilePath = Path.Combine(_compressedFolderPath, dto.CompressedFileName ?? GeneratePassword.GeneratePasswordHandle(_passwordGeneratorLength) + Path.GetExtension(dto.OriginalFileName));
            string password = dto.Password ?? GeneratePassword.GeneratePasswordHandle(_passwordGeneratorLength);

            CompressFile.CompressFileHandler(dto.CompressionFormat, temporaryFilePath, compressedFilePath, password);

            if (dto.IsDeleteOriginalFile)
            {
                File.Delete(temporaryFilePath);
            }

            fileData.Path = compressedFilePath;
            return compressedFilePath;
        }
        else
        {
            string destinationFilePath = Path.Combine(dto.StoragePath, dto.OriginalFileName);
            File.Move(temporaryFilePath, destinationFilePath);

            fileData.Path = destinationFilePath;
            return destinationFilePath;
        }
    }


    // Update File
    private void UpdateFileData(Storage_Manager_Dto dto, AppFile fileData)
    {
        fileData.Title = dto.OriginalFileName;
        fileData.Description = dto.Description;
        fileData.Path = dto.StoragePath; // Update path only if provided in DTO
        fileData.Version++;
        fileData.IsPublic = false; // Mark previous version inactive
    }


    // Create Directories
    private void CreateDirectories(string compressedFolderPath, string temporaryFolderPath)
    {
        Directory.CreateDirectory(compressedFolderPath);
        Directory.CreateDirectory(temporaryFolderPath);
    }
}


