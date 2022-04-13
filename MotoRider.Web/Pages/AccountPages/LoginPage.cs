using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace MotoRider.Web.Pages.AccountPages
{
    public partial class LoginPage
    {
        [Inject]
        public IAuthenticationApiService AuthenticationApiService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        public UserAuthentication UserModel { get; set; } = new();

        public string ErrorMessage { get; set; } = "";

        private async Task HandleLoginUser()
        {
            try
            {
                string token = await AuthenticationApiService.LoginUser(UserModel);
                await SessionStorage.SetItemAsStringAsync("Token", token);
                
                await SessionStorage.SetItemAsStringAsync("User", $"{UserModel.Username}");

                NavigationManager.NavigateTo("/", true);
            }
            catch (Exception)
            {
                ErrorMessage = "Unable to authenticate user.";
            }
        }
    }
}
