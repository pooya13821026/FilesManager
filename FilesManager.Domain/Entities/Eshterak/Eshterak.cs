using FilesManager.Domain.Common;

namespace FilesManager.Domain.Entities.Eshterak;

public class Eshterak : EntityBase<Guid>
{
    public Guid FileId { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
