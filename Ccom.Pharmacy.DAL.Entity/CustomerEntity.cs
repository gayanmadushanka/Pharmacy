using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class CustomerEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string ContactNumber { get; set; }
    }
}
