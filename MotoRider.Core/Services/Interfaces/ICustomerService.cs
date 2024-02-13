using MotoRider.Shared.Models;
using System.Collections.Generic;

namespace MotoRider.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(int id);

        bool InsertCustomer(Customer customer);

        bool UpdateCustomer(int id, Customer customer);

        bool DeleteCustomer(int id);
    }
}
