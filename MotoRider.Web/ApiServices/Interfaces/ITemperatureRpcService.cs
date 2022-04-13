using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices.Interfaces
{
    public interface ITemperatureRpcService
    {
        Task<string> GetTemperatureAsync(string cityName);
    }
}
