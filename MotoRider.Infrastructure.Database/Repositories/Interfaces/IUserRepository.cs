using MotoRider.Shared.Models;

namespace MotoRider.Infrastructure.Database.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetUserByUsername(string username);

        public User GetUserByUsernameAndPasswordHash(string username, string passwordHash);
    }
}
