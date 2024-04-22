using FilesManager.Application.Contracts.Persistence.Common;
using FilesManager.Application.Features.User.Query;
using FilesManager.Application.Models.DTOs.AppUser;
using FilesManager.Domain.Entities.AppUser;

namespace FilesManager.Application.Contracts.Persistence.AppUser;
public interface IUserRepository : ISearchRepository<Guid, User, User_List_Dto, User_List_Item_Dto, GetUserQuery>
{

}
