using FilesManager.Domain.Entities.File;
using FilesManager.Infrastructure.Data;


namespace FilesManager.Infrastructure.Implementation.Repositories.StorageManager;
public class StorageManagerRepository : WriteRepository<AppFile,Guid>
{
    public StorageManagerRepository(ApplicationContext context) : base(context)
    {
    }
}
