using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.CustomerManagementPages
{
    public partial class CustomerManagementCreatePage
    {
        [Inject]
        public ICustomerApiService CustomerApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Customer CustomerModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        private async Task HandleCreateCustomer()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                await CustomerApiService.InsertCustomerAsync(token, CustomerModel);

                NavigationManager.NavigateTo($"/customer-management");
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to create customer.";
            }
        }
    }
}
