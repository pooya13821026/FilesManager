using FilesManager.Domain.Common;

namespace FilesManager.Domain.Entities.AppUser;
public class Role : IEntityBase<Guid>
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}
