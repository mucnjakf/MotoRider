using MotoRider.SOAP.Services;
using SoapService;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MotoRider.SOAP.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string next;
            do
            {
                Console.WriteLine("Motorcycle Search SOAP Service");

                Console.Write("Insert motorcycle make: ");
                string motorcycleMake = Console.ReadLine();

                MotorcycleSearchServiceSoapClient service = new(MotorcycleSearchServiceSoapClient.EndpointConfiguration.MotorcycleSearchServiceSoap);

                var result = service.SearchByMotorcycleMakeAsync(motorcycleMake).Result;

                var serializer = new XmlSerializer(typeof(Motorcycle));
                var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result.Body.SearchByMotorcycleMakeResult));

                var motorcycle = (Motorcycle)serializer.Deserialize(memoryStream);

                Console.WriteLine(motorcycle);

                Console.Write("Continue? (Y/N) > ");
                next = Console.ReadLine().ToLower();

                Console.Clear();
            } while (next != "n");
        }
    }
}
