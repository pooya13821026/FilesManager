using FilesManager.Application.Models.DTOs.StorageManager;

namespace FilesManager.Application.Contracts.Services;
public interface IStorageManager
{
    Task<string> SaveStorageFile(Storage_Manager_Dto dto);
}
