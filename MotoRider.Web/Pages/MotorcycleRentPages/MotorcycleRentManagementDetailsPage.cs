using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.MotorcycleRentPages
{
    public partial class MotorcycleRentManagementDetailsPage
    {
        [Inject]
        public IMotorcycleRentApiService MotorcycleRentApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Rent RentModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            RentModel.Motorcycle = new();
            RentModel.Customer = new();

            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                RentModel = await MotorcycleRentApiService.GetMotorcycleRentAsync(token, int.Parse(Id));
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load motorcycle rent.";
            }
        }
    }
}
