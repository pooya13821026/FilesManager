namespace FilesManager.Application.Contracts.Data;
public interface IApplicationContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}