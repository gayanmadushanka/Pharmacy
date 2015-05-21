using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class UserRoleEntity
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
        public virtual ICollection<ModuleEntity> ModuleEntities { get; set; }

        [DataMember]
        public ICollection<UserEntity> UserEntities { get; set; }

        //[DataMember]
        //public ICollection<SubModuleEntity> SubModuleEntities { get; set; }
    }
}
