using FilesManager.Application.Contracts.Persistence.Eshterak;
using FilesManager.Infrastructure.Data;
using EshterakEntity = FilesManager.Domain.Entities.Eshterak.Eshterak;

namespace FilesManager.Infrastructure.Implementation.Repositories.Eshterak;
public class EshterakWriteRepository : WriteRepository<EshterakEntity, Guid>, IEshterakRepository
{
    public EshterakWriteRepository(ApplicationContext context) : base(context)
    {
    }
}
