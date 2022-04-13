using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MotoRider.Shared.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/MotoRider.Shared.Models")]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
