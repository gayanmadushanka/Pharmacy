using System;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
   [DataContract]
    public class ReportingEntity
    {
        [DataMember]
       public DateTime FromDate { get; set; }

        [DataMember]
        public DateTime ToDate { get; set; }
    }
}
