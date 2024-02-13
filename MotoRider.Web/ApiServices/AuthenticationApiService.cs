using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices
{
    public class AuthenticationApiService : IAuthenticationApiService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task RegisterUser(UserAuthentication userAuthentication)
        {
            StringContent data = new(JsonConvert.SerializeObject(userAuthentication), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("api/account/register", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> LoginUser(UserAuthentication userAuthentication)
        {
            StringContent data = new(JsonConvert.SerializeObject(userAuthentication), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("api/account/authenticate", data);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
