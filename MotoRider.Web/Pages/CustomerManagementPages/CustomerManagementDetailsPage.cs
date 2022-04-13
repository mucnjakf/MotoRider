using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.CustomerManagementPages
{
    public partial class CustomerManagementDetailsPage
    {
        [Inject]
        public ICustomerApiService CustomerApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Customer CustomerModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                CustomerModel = await CustomerApiService.GetCustomerAsync(token, int.Parse(Id));
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load customer.";
            }
        }
    }
}
