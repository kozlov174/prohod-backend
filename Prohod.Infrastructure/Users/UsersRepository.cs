using Kontur.Results;
using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Database;

namespace Prohod.Infrastructure.Users;

public class UsersRepository : IUsersRepository
{
    private readonly IAppDbContext dbContext;

    public UsersRepository(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<Result<UserNotFoundError, User>> GetUserByLoginAndPasswordHash(string login, string passwordHash)
    {
        var user = await dbContext.Users
            .SingleOrDefaultAsync(user => user.Login == login && user.PasswordHash == passwordHash);

        if (user is null)
        {
            return new UserNotFoundError("No user with provided login and password was found");
        }

        return user;
    }
}