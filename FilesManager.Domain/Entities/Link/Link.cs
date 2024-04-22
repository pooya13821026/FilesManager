using FilesManager.Domain.Common;

namespace FilesManager.Domain.Entities.Link;
public class Link : EntityBase<Guid>
{
    public string Code { get; set; }
    public bool Enpirable { get; set; }
    public DateTime LastSeenDate { get; set; }
    public Guid FileId { get; set; }
}
