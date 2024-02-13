using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices
{
    public class MotorcycleApiService : IMotorcycleApiService
    {
        private readonly HttpClient _httpClient;

        public MotorcycleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Motorcycle>> GetMotorcyclesAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync("api/motorcycle");
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            IEnumerable<Motorcycle> motorcycles = JsonConvert.DeserializeObject<IEnumerable<Motorcycle>>(result);

            return motorcycles;
        }

        public async Task<Motorcycle> GetMotorcycleAsync(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync($"api/motorcycle/{id}");
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            Motorcycle motorcycle = JsonConvert.DeserializeObject<Motorcycle>(result);
            return motorcycle;
        }

        public async Task InsertMotorcycleAsync(string token, Motorcycle motorcycle)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.PostAsync("api/motorcycle", motorcycle, new XmlMediaTypeFormatter());
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateMotorcycleAsync(string token, int id, Motorcycle motorcycle)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.PutAsync($"api/motorcycle/{id}", motorcycle, new XmlMediaTypeFormatter());
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMotorcycleAsync(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/motorcycle/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
