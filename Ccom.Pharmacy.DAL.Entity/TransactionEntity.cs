using System;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class TransactionEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public ItemEntity ItemEntity { get; set; }

        [DataMember]
        public DateTime? Date { get; set; }
    }
}
