using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class InvoiceEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string InvoiceNo { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public double TotalAmount { get; set; }

        [DataMember]
        public double SubAmount { get; set; }

        [DataMember]
        public double Cash { get; set; }

        [DataMember]
        public double Balance { get; set; }

        [DataMember]
        public double Discount { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public ICollection<InvoiceItemEntity> InvoiceItemEntities { get; set; }
    }
}
