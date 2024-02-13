using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.MotorcycleManagementPages
{
    public partial class MotorcycleManagementPage
    {
        [Inject]
        public IMotorcycleApiService MotorcycleApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        public List<Motorcycle> MotorcyclesModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                IEnumerable<Motorcycle> result = await MotorcycleApiService.GetMotorcyclesAsync(token);
                MotorcyclesModel = result.ToList();
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load motorcycles.";
            }
        }

        private async Task HandleDeleteMotorcycle(int id)
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                await MotorcycleApiService.DeleteMotorcycleAsync(token, id);
                MotorcyclesModel.RemoveAll(motorcycle => motorcycle.Id == id);
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to delete motorcycle.";
            }
        }
    }
}