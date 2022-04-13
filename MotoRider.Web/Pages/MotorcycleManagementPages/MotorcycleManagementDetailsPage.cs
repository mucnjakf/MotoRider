using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.MotorcycleManagementPages
{
    public partial class MotorcycleManagementDetailsPage
    {
        [Inject]
        public IMotorcycleApiService MotorcycleApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Motorcycle MotorcycleModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                MotorcycleModel = await MotorcycleApiService.GetMotorcycleAsync(token, int.Parse(Id));
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load motorcycle.";
            }
        }
    }
}
