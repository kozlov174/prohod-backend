using AutoMapper;
using Kontur.Results;
using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Database;

namespace Prohod.Infrastructure.Users;

public class UsersRepository : IUsersRepository
{
    private readonly IApplicationDbContext dbContext;
    private readonly IMapper mapper;

    public UsersRepository(IApplicationDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    public async Task<Result<UserNotFoundError, User>> GetUserByLoginAndPasswordHash(string login, string passwordHash)
    {
        var user = await dbContext.Users
            .SingleOrDefaultAsync(user => user.Login == login && user.PasswordHash == passwordHash);

        if (user is null)
        {
            return new UserNotFoundError("No user with provided login and password was found");
        }

        return mapper.Map<User>(user);
    }
}