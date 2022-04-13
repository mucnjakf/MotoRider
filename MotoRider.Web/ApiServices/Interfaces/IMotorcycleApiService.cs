using MotoRider.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices.Interfaces
{
    public interface IMotorcycleApiService
    {
        Task<IEnumerable<Motorcycle>> GetMotorcyclesAsync(string token);
        Task<Motorcycle> GetMotorcycleAsync(string token, int id);
        Task InsertMotorcycleAsync(string token, Motorcycle motorcycle);
        Task UpdateMotorcycleAsync(string token, int id, Motorcycle motorcycle);
        Task DeleteMotorcycleAsync(string token, int id);
    }
}
