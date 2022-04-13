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
    public partial class MotorcycleRentManagementPage
    {
        [Inject]
        public IMotorcycleRentApiService MotorcycleRentApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        public string ErrorMessage { get; set; } = "";

        public List<Rent> RentModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                IEnumerable<Rent> result = await MotorcycleRentApiService.GetMotorcycleRentsAsync(token);
                RentModel = result.ToList();
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load motorcycle rents.";
            }
        }

        private async Task HandleDeleteMotorcycleRent(int id)
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                await MotorcycleRentApiService.DeleteMotorcycleRentAsync(token, id);
                RentModel.RemoveAll(rent => rent.Id == id);
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to delete motorcycle rent.";
            }
        }
    }
}
