using System.Collections.Generic;

namespace Ccom.Pharmacy.Core.DomainObjects
{
    public class IOSGuest
    {
        public List<IOSUniqueId> ProfileIdList { get; set; }

        public int Id { get; set; }

        public string Salutation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nationality { get; set; }

        public string CountyOfResident { get; set; }

        public string Occupant { get; set; }

        //public IOSGender Gender { get; set; }

        //public bool IsEditBtnEnable { get; set; }

        //public List<IOSEmail> EmailList { get; set; }

        //public List<IOSPhone> PhoneList { get; set; }

        //public List<IOSAddress> AddressList { get; set; }

        //public IOSGovernmentId GovernmentId { get; set; }

        public bool GuestAuthorizationCompleted { get; set; }

        public bool IsReserveGuest { get; set; }

        public IOSGuest()
        {
            ProfileIdList = new List<IOSUniqueId>();
            //EmailList = new List<IOSEmail>();
            //PhoneList = new List<IOSPhone>();
            //AddressList = new List<IOSAddress>();
            //GovernmentId = new IOSGovernmentId();
        }
    }
}
