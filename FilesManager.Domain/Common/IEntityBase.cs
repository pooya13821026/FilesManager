using System.ComponentModel.DataAnnotations;

namespace FilesManager.Domain.Common;

public interface IEntityBase<TKey>
{
    [Key]
    public TKey Id { get; set; }
    public bool IsDeleted { get; set; }
}