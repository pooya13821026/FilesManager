using FilesManager.Application.Contracts.Persistence.File;
using FilesManager.Infrastructure.Data;
using FileEntity = FilesManager.Domain.Entities.File.AppFile;


namespace FilesManager.Infrastructure.Implementation.Repositories.File;
public class FileWriteRepository : WriteRepository<FileEntity, Guid>, IFileRepository
{
    public FileWriteRepository(ApplicationContext context) : base(context)
    {
    }
}
