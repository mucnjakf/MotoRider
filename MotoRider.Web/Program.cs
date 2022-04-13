using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MotoRider.Web.ApiServices;
using MotoRider.Web.ApiServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;

namespace MotoRider.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredSessionStorage();

            builder.Services.AddHttpClient<IMotorcycleApiService, MotorcycleApiService>(httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]));
            builder.Services.AddHttpClient<ICustomerApiService, CustomerApiService>(httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]));
            builder.Services.AddHttpClient<IMotorcycleRentApiService, MotorcycleRentApiService>(httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]));
            builder.Services.AddHttpClient<IAuthenticationApiService, AuthenticationApiService>(httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]));

            builder.Services.AddTransient<ITemperatureRpcService, TemperatureRpcService>();

            await builder.Build().RunAsync();
        }
    }
}
