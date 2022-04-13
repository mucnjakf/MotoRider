using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace MotoRider.RPC.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string next;
            do
            {
                Console.WriteLine("City Temperature RPC Service");

                Console.Write("Insert city name: ");
                string cityName = Console.ReadLine();

                XmlDocument doc = new();
                doc.Load("DataTemplate.xml");

                doc.DocumentElement.ChildNodes[0].InnerText = "DhmzService.getTemperature";
                doc.DocumentElement.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText = cityName;

                MemoryStream memoryStream = new();
                doc.Save(memoryStream);

                byte[] data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(memoryStream.ToArray()));

                var request = (HttpWebRequest)WebRequest.Create("http://localhost:8080");
                request.Method = "POST";
                request.Accept = "application/xml";
                request.ContentType = "application/xml";

                Stream streamRequest = request.GetRequestStream();
                streamRequest.Write(data, 0, data.Length);
                streamRequest.Close();

                var response = (HttpWebResponse)request.GetResponse();
                Stream streamResponse = response.GetResponseStream();

                XmlDocument responseDoc = new();
                responseDoc.Load(streamResponse);

                var result = responseDoc.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText;

                Console.WriteLine($"Temperature in {cityName} is{result}°C\n");

                Console.Write("Continue? (Y/N) > ");
                next = Console.ReadLine().ToLower();

                Console.Clear();
            } while (next != "n");
        }
    }
}
