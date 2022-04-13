using MotoRider.SOAP.Services;
using Saxon.Api;
using System.IO;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;

namespace MotoRider.SOAP
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MotorcycleSearchService : WebService
    {
        [WebMethod]
        public string SearchByMotorcycleMake(string searchTerm)
        {
            var motorcycles = MotorcycleService.GetMotorcycles();

            string xmlString;

            var xmlSerializer = new XmlSerializer(motorcycles.GetType());

            using (var memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, motorcycles);
                memoryStream.Position = 0;
                xmlString = new StreamReader(memoryStream).ReadToEnd();
            }

            var expression = $"/ArrayOfMotorcycle/Motorcycle[Make=\"{searchTerm}\"]";

            var processor = new Processor();
            var compiler = processor.NewXPathCompiler();
            var executable = compiler.Compile(expression);
            var evaluator = executable.Load();

            var stringReader = new StringReader(xmlString);
            var xmlReader = XmlReader.Create(stringReader);

            XdmNode node = processor.NewDocumentBuilder().Build(xmlReader);
            evaluator.ContextItem = node;
            XdmItem result = evaluator.EvaluateSingle();

            foreach (XdmNode item in result)
            {
                return item.OuterXml;
            }

            return "";
        }
    }
}
