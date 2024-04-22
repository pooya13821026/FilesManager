namespace FilesManager.Domain.Common;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    public TKey Id { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
}

