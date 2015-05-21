using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class UserCategoryEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        [DataMember]
        public virtual ICollection<UserEntity> UserEntities { get; set; }
    }
}
