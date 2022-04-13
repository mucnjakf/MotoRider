using MotoRider.Web.ApiServices.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Xml;

namespace MotoRider.Web.ApiServices
{
    public class TemperatureRpcService : ITemperatureRpcService
    {
        public async Task<string> GetTemperatureAsync(string cityName)
        {
            XmlDocument doc = new();

            HttpClient hc1 = new()
            {
                BaseAddress = new Uri("https://localhost:5003/")
            };

            var stream = await hc1.GetStreamAsync("Data/RpcDataTemplate.xml");
            doc.Load(stream);

            doc.DocumentElement.ChildNodes[0].InnerText = "DhmzService.getTemperature";
            doc.DocumentElement.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText = cityName;

            HttpClient hc2 = new()
            {
                BaseAddress = new Uri("http://localhost:8080")
            };

            HttpResponseMessage response = await hc2.PostAsync("", doc, new XmlMediaTypeFormatter());
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
