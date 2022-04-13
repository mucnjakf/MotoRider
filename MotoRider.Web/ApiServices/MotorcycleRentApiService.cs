using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices
{
    public class MotorcycleRentApiService : IMotorcycleRentApiService
    {
        private readonly HttpClient _httpClient;

        public MotorcycleRentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Rent>> GetMotorcycleRentsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync("api/rent");
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            IEnumerable<Rent> rents = JsonConvert.DeserializeObject<IEnumerable<Rent>>(result);

            return rents;
        }

        public async Task<Rent> GetMotorcycleRentAsync(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync($"api/rent/{id}");
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            Rent rent = JsonConvert.DeserializeObject<Rent>(result);
            return rent;
        }

        public async Task InsertMotorcycleRentAsync(string token, Rent rent)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            StringContent data = new(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("api/rent", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateMotorcycleRentAsync(string token, int id, Rent rent)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            JsonSerializerSettings jsonSettings = new() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

            StringContent data = new(JsonConvert.SerializeObject(rent, jsonSettings), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync($"api/rent/{id}", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMotorcycleRentAsync(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/rent/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
