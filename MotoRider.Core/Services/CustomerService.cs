using MotoRider.Core.Services.Interfaces;
using MotoRider.Infrastructure.Database.Core;
using MotoRider.Infrastructure.Database.Core.Interfaces;
using MotoRider.Shared.Models;
using System;
using System.Collections.Generic;

namespace MotoRider.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService()
        {
            _unitOfWork = new UnitOfWork(new MotoRiderDbContext());
        }

        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                return _unitOfWork.Customers.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return _unitOfWork.Customers.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertCustomer(Customer customer)
        {
            try
            {
                _unitOfWork.Customers.Add(customer);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(int id, Customer customer)
        {
            try
            {
                Customer customerToUpdate = _unitOfWork.Customers.Get(id);

                if (customerToUpdate == null) return false;

                customerToUpdate.FirstName = customer.FirstName;
                customerToUpdate.LastName = customer.LastName;
                customerToUpdate.PhoneNumber = customer.PhoneNumber;

                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                Customer customer = _unitOfWork.Customers.Get(id);

                if (customer == null) return false;

                _unitOfWork.Customers.Remove(customer);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
