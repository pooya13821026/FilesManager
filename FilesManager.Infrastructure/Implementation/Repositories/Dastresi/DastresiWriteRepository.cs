using FilesManager.Application.Contracts.Persistence.Dastresi;
using DastresiEntity = FilesManager.Domain.Entities.Dastresi.Dastresi;
using FilesManager.Infrastructure.Data;

namespace FilesManager.Infrastructure.Implementation.Repositories.Dastresi;
public class DastresiWriteRepository : WriteRepository<DastresiEntity, Guid>, IDastresiRepository
{
    public DastresiWriteRepository(ApplicationContext context) : base(context)
    {
    }
}

