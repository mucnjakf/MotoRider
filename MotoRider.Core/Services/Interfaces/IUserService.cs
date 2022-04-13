using MotoRider.Shared.Models;

namespace MotoRider.Core.Services.Interfaces
{
    public interface IUserService
    {
        User GetUser(string username, string password);

        bool InsertUser(UserAuthentication userAuthentication);
    }
}
