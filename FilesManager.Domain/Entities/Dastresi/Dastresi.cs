using FilesManager.Domain.Common;

namespace FilesManager.Domain.Entities.Dastresi;
public class Dastresi : EntityBase<Guid>
{
    public Guid FileId { get; set; }
    public Guid UserId { get; set; }
    public Guid RelationTypeId { get; set; }
    public Guid RoleId { get; set; }
    public Guid UserRelationType { get; set; }
    public Guid UserRoleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsAllowed { get; set; }
}
