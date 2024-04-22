using FilesManager.Application.Models.DTOs.StorageManager;
using FluentValidation;

namespace FilesManager.Application.Common.Validations;
public class StorageFileValidator : AbstractValidator<Storage_Manager_Dto>
{
    private string Success_IR = Properties.Resources_IR.SUCCESS;
    private string Error_IR = Properties.Resources_IR.ERROR;
    private string Warning_IR = Properties.Resources_IR.WARNING;


    private string Success_US = Properties.Resources_US.SUCCESS;
    private string Error_US = Properties.Resources_US.ERROR;
    private string Warning_US = Properties.Resources_US.WARNING;
    public StorageFileValidator()
    {
        // Client and Secret validation (assuming they are required and unique)
        RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("Client ID is required.");

        RuleFor(x => x.ClientId)
            .Must(HaveUniqueClientId)
            .WithMessage("Client ID must be unique.");

        RuleFor(x => x.SecretId)
            .NotEmpty()
            .WithMessage("Secret ID is required.");

        RuleFor(x => x.SecretId)
            .Must(HaveUniqueSecretId)
            .WithMessage("Secret ID must be unique.");

        // Token validation (assuming it's required)
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("Token is required.");

        // Description validation (optional)
        RuleFor(x => x.Description)
            .Length(0, 255)
            .WithMessage("Description cannot exceed 255 characters.");

        // File validation
        RuleFor(x => x.File)
            .NotEmpty()
            .WithMessage("Please select a file to compress.");

        RuleFor(x => x.File)
            .Custom((file, context) =>
            {
                if (file.Length == 0)
                {
                    context.AddFailure("Selected file is empty.");
                }
            });

        // Compression format validation
        RuleFor(x => x.CompressionFormat)
            .NotEmpty()
            .WithMessage("Please select a compression format.");

        // Password validation (conditional on IsCompressFile being true)
        When(x => x.IsCompressFile, () =>
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required for compression.");

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");

            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^\w]).{8,}$")
                .WithMessage("Password must contain lowercase, uppercase, numbers, and special characters.");
        });

        // Compressed file name validation (optional)
        RuleFor(x => x.CompressedFileName)
            .Length(0, 255)
            .WithMessage("Compressed file name cannot exceed 255 characters.");

        // Storage path validation (optional)
        RuleFor(x => x.StoragePath)
            .Length(0, 255)
            .WithMessage("Storage path cannot exceed 255 characters.");

        // IsPublic validation (optional)
    }

    private static bool HaveUniqueClientId(Guid clientId)
    {
        return true;
    }

    private static bool HaveUniqueSecretId(Guid secretId)
    {
        return true;
    }
}



