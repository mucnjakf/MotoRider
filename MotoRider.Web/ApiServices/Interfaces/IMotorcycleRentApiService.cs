using MotoRider.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices.Interfaces
{
    public interface IMotorcycleRentApiService
    {
        Task<IEnumerable<Rent>> GetMotorcycleRentsAsync(string token);
        Task<Rent> GetMotorcycleRentAsync(string token, int id);
        Task InsertMotorcycleRentAsync(string token, Rent rent);
        Task UpdateMotorcycleRentAsync(string token, int id, Rent rent);
        Task DeleteMotorcycleRentAsync(string token, int id);
    }
}
