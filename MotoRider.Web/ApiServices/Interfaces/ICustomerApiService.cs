using MotoRider.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices.Interfaces
{
    public interface ICustomerApiService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(string token);
        Task<Customer> GetCustomerAsync(string token, int id);
        Task InsertCustomerAsync(string token, Customer customer);
        Task UpdateCustomerAsync(string token, int id, Customer customer);
        Task DeleteCustomerAsync(string token, int id);
    }
}
