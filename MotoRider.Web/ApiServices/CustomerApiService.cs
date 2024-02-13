using MotoRider.Shared.Models;
using MotoRider.Web.ApiServices.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MotoRider.Web.ApiServices
{
    public class CustomerApiService : ICustomerApiService
    {
        private readonly HttpClient _httpClient;

        public CustomerApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync("api/customer");
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(result);

            return customers;
        }

        public async Task<Customer> GetCustomerAsync(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync($"api/customer/{id}");
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            Customer customer = JsonConvert.DeserializeObject<Customer>(result);
            return customer;
        }

        public async Task InsertCustomerAsync(string token, Customer customer)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            StringContent data = new(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("api/customer", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCustomerAsync(string token, int id, Customer customer)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            StringContent data = new(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync($"api/customer/{id}", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCustomerAsync(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);

            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/customer/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
