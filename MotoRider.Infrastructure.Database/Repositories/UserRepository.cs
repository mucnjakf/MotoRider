using MotoRider.Infrastructure.Database.Core;
using MotoRider.Infrastructure.Database.Repositories.Interfaces;
using MotoRider.Shared.Models;
using System.Linq;

namespace MotoRider.Infrastructure.Database.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public MotoRiderDbContext MotoRiderDbContext { get { return Context as MotoRiderDbContext; } }

        public UserRepository(MotoRiderDbContext context) : base(context)
        {
        }

        public User GetUserByUsername(string username) => MotoRiderDbContext.Users.Where(user => user.Username == username).FirstOrDefault();

        public User GetUserByUsernameAndPasswordHash(string username, string passwordHash) => MotoRiderDbContext.Users.Where(user => user.Username == username && user.PasswordHash == passwordHash).FirstOrDefault();
    }
}
