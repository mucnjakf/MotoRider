using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.MotorcycleRentPages
{
    public partial class MotorcycleRentManagementEditPage
    {
        [Inject]
        public IMotorcycleRentApiService MotorcycleRentApiService { get; set; }

        [Inject]
        public IMotorcycleApiService MotorcycleApiService { get; set; }

        [Inject]
        public ICustomerApiService CustomerApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public string ErrorMessage { get; set; } = "";

        public Rent RentModel { get; set; } = new();
        public List<Motorcycle> MotorcyclesModel { get; set; } = new();
        public List<Customer> CustomersModel { get; set; } = new();

        private string _motorcycleId;
        private string _customerId;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");

                RentModel = await MotorcycleRentApiService.GetMotorcycleRentAsync(token, int.Parse(Id));

                IEnumerable<Motorcycle> motorcycle = await MotorcycleApiService.GetMotorcyclesAsync(token);
                MotorcyclesModel = motorcycle.Where(motorcycle => motorcycle.AvailableForRent == true || motorcycle.Make == RentModel.Motorcycle.Make && motorcycle.Model == RentModel.Motorcycle.Model).ToList();

                IEnumerable<Customer> customers = await CustomerApiService.GetCustomersAsync(token);
                CustomersModel = customers.ToList();

                _motorcycleId = RentModel.MotorcycleId.ToString();
                _customerId = RentModel.CustomerId.ToString();
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load motorcycle rent.";
            }
        }

        private async Task HandleEditMotorcycleRent()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");

                RentModel.MotorcycleId = int.Parse(_motorcycleId);
                RentModel.CustomerId = int.Parse(_customerId);

                await MotorcycleRentApiService.UpdateMotorcycleRentAsync(token, RentModel.Id, RentModel);

                NavigationManager.NavigateTo("/rent-management");
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to update motorcycle rent.";
            }
        }
    }
}
