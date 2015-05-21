using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class UserEntity
    {
        [DataMember]
        public int Id { get; set; }

        //[DataMember]
        ////[NotMapped]
        //public string Name
        //{
        //    get
        //    {
        //        return FirstName + " " + MiddleName;
        //    }
        //}

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int UserRoleId { get; set; }

        //[DataMember]
        //public int UserCategoryId { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string HomeNumber { get; set; }

        [DataMember]
        public string OfficeNumber { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        [DataMember]
        public virtual UserRoleEntity UserRole { get; set; }

        //[DataMember]
        //public UserCategoryEntity UserCategory { get; set; }
    }
}
