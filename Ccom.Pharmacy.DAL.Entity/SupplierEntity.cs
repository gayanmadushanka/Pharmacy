using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public sealed class SupplierEntity
    {
        public SupplierEntity()
        {
            ItemEntities = new HashSet<ItemEntity>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string ContactNumber { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public ICollection<ItemEntity> ItemEntities { get; set; }
    }
}
