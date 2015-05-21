using System;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.ViewModels
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string BrandName { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public double ActualPrice { get; set; }

        [DataMember]
        public double Discount { get; set; }

        //[DataMember]
        //public SupllierEntity Supllier { get; set; }

        [DataMember]
        public DateTime ExpireDate { get; set; }
    }
}
