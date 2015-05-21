using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class InvoiceItemEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public double TotalAmount { get; set; }

        [DataMember]
        public int InvoiceId { get; set; }

        [DataMember]
        public InvoiceEntity Invoice { get; set; }

        [DataMember]
        public virtual ItemEntity Item { get; set; }
    }
}
