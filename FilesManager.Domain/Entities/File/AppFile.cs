using FilesManager.Domain.Common;

namespace FilesManager.Domain.Entities.File;

public class AppFile : EntityBase<Guid>
{
    public Guid SamanehId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public Guid GroupId { get; set; }
    public int Version { get; set; }
    public DateTime Date { get; set; }
    public int ViewQuentity { get; set; }
    public string Path { get; set; }
}

