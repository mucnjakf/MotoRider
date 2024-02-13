using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using SoapServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.MotorcycleRentPages
{
    public partial class MotorcycleRentPage
    {
        [Inject]
        public IMotorcycleApiService MotorcycleApiService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        public List<Motorcycle> MotorcyclesModel { get; set; } = new();

        public string SearchTerm { get; set; } = "";

        public string SearchedMotorcycle { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await SessionStorage.GetItemAsStringAsync("Token");
                IEnumerable<Motorcycle> result = await MotorcycleApiService.GetMotorcyclesAsync(token);
                MotorcyclesModel = result.Where(motorcycle => motorcycle.AvailableForRent == true).ToList();
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to load motorcycles.";
            }
        }

        private async Task SearchMotorcycle()
        {
            MotorcycleSearchServiceSoapClient service = new(MotorcycleSearchServiceSoapClient.EndpointConfiguration.MotorcycleSearchServiceSoap);

            var result = await service.SearchByMotorcycleMakeAsync(SearchTerm);

            SearchedMotorcycle = result.Body.SearchByMotorcycleMakeResult;
        }
    }
}
