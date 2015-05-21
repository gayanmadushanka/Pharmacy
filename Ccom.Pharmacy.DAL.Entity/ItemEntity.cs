using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ccom.Pharmacy.DAL.Entity
{
    [DataContract]
    public class ItemEntity : IDataErrorInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public double WholeSalePrice { get; set; }

        [DataMember]
        public double UnitPrice { get; set; }

        [DataMember]
        public double TotalAmount { get; set; }

        [DataMember]
        public double? Discount { get; set; }

        [DataMember]
        public DateTime? ExpireDate { get; set; }

        [DataMember]
        public int SupplierId { get; set; }

        [DataMember]
        public int ItemCategoryId { get; set; }

        [DataMember]
        public virtual ItemCategoryEntity ItemCategory { get; set; }

        [DataMember]
        public virtual SupplierEntity Supplier { get; set; }

        public ItemEntity()
        {
            Name = string.Empty;
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "Name")
                {
                    if (Name.Length > 200)
                    {
                        result = "Name shouldn't be Greter than 200.";
                    }
                }
                return result;
            }
        }
    }
}
