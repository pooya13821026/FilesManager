using FilesManager.Domain.Enum.CompressionFormat;
using Microsoft.AspNetCore.Http;

namespace FilesManager.Application.Models.DTOs.StorageManager;
public class Storage_Manager_Dto
{
    public Guid? Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid SecretId { get; set; }
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public string? Description { get; set; }
    public IFormFile File { get; set; }
    public string OriginalFileName => File.FileName;
    public bool IsCompressFile { get; set; }
    public Compression_Format_Enum CompressionFormat { get; set; }
    public string? CompressedFileName { get; set; }
    public string? Password { get; set; }
    public string StoragePath { get; set; } = string.Empty;
    public bool IsDeleteOriginalFile { get; set; }
    public bool IsPublic { get; set; }
}
