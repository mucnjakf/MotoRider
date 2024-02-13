using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.CustomerManagementPages
{
    public partial class CustomerManagementPage
    {
        [Inject]
        public ICustomerApiService CustomerApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        public List<Customer> CustomersModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                IEnumerable<Customer> result = await CustomerApiService.GetCustomersAsync(token);
                CustomersModel = result.ToList();
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load customers.";
            }
        }

        private async Task HandleDeleteCustomer(int id)
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                await CustomerApiService.DeleteCustomerAsync(token, id);
                CustomersModel.RemoveAll(customer => customer.Id == id);
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to delete customer.";
            }
        }
    }
}
