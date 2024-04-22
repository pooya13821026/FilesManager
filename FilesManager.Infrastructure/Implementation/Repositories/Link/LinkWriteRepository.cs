using FilesManager.Application.Contracts.Persistence.Link;
using FilesManager.Infrastructure.Data;
using LinkEntity = FilesManager.Domain.Entities.Link.Link;

namespace FilesManager.Infrastructure.Implementation.Repositories.Link;
public class LinkWriteRepository : WriteRepository<LinkEntity, Guid>, ILinkRepository
{
    public LinkWriteRepository(ApplicationContext context) : base(context)
    {
    }
}
