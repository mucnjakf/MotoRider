using System.Runtime.Serialization;

namespace MotoRider.Shared.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/MotoRider.Shared.Models")]
    public class Motorcycle
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Make { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public int YearOfManufacture { get; set; }

        [DataMember]
        public int Mileage { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public bool AvailableForRent { get; set; }
    }
}
