using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public sealed class ItemCategoryEntity
    {
        public ItemCategoryEntity()
        {
            ItemEntities = new HashSet<ItemEntity>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<ItemEntity> ItemEntities { get; set; }
    }
}
