using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class ItemConfiguration : EntityTypeConfiguration<ItemEntity>
    {
        public ItemConfiguration()
        {
            ToTable(ConstantManager.ItemTableName);
            HasKey(c => c.Id);
            Property(c => c.Code).HasMaxLength(ConstantManager.CodePropertyLength);
            Property(c => c.Name).HasMaxLength(ConstantManager.NamePropertyLength);
            Property(c => c.UnitPrice);
            Property(c => c.WholeSalePrice);
            Property(c => c.TotalAmount);
            Property(c => c.ExpireDate);
            Property(c => c.Discount);
            //HasOptional(p => p.ItemCategory).WithOptionalPrincipal().WillCascadeOnDelete(false);
            HasRequired(c => c.ItemCategory);
            HasRequired(c => c.Supplier);
            //HasOptional(c => c.ItemCategory);
            //HasOptional(c => c.Supplier);
        }
    }
}
