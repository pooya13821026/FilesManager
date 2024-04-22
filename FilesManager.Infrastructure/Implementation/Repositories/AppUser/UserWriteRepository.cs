using AutoMapper;
using FilesManager.Application.Contracts.Persistence.AppUser;
using FilesManager.Application.Contracts.Persistence.Common;
using FilesManager.Application.Features.User.Query;
using FilesManager.Application.Models.DTOs.AppUser;
using FilesManager.Domain.Entities.AppUser;
using FilesManager.Domain.Enum.Order;
using FilesManager.Infrastructure.Data;
using FilesManager.Infrastructure.Implementation.Common;
using System.Linq.Expressions;

namespace FilesManager.Infrastructure.Implementation.Repositories.AppUser;
public class UserWriteRepository: WriteRepository<User, Guid>, IUserRepository
{
    private readonly IMapper _mapper;


    public UserWriteRepository(ApplicationContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public Dictionary<string, IOrderBy> OrderFunctions { get; init; } = new()
    {
        { nameof(User.BirthDate), new OrderBy<User, DateTime?>(x => x.BirthDate) }
    };





    public Task<User_List_Dto> Search(GetUserQuery search)
    {
        throw new NotImplementedException();
    }




    public Expression<Func<User, bool>>? GetExpression(GetUserQuery search)
    {
        throw new NotImplementedException();
    }



    public Tuple<List<IOrderBy>, OrderTypeEnum?>? GetOrder(GetUserQuery search)
    {
        throw new NotImplementedException();
    }
}
