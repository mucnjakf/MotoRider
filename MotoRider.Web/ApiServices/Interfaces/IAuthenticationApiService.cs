using MotoRider.Shared.Models;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices.Interfaces
{
    public interface IAuthenticationApiService
    {
        Task RegisterUser(UserAuthentication userAuthentication);

        Task<string> LoginUser(UserAuthentication userAuthentication);
    }
}
