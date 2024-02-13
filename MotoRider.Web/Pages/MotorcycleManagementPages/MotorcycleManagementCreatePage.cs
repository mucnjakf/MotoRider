using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.MotorcycleManagementPages
{
    public partial class MotorcycleManagementCreatePage
    {
        [Inject]
        public IMotorcycleApiService MotorcycleApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Motorcycle MotorcycleModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        private async Task HandleCreateMotorcycle()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                await MotorcycleApiService.InsertMotorcycleAsync(token, MotorcycleModel);

                NavigationManager.NavigateTo($"/motorcycle-management");
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to create motorcycle.";
            }
        }
    }
}
