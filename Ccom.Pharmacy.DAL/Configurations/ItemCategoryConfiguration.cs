using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class ItemCategoryConfiguration : EntityTypeConfiguration<ItemCategoryEntity>
    {
        public ItemCategoryConfiguration()
        {
            ToTable(ConstantManager.ItemCategoryTableName);
            HasKey(c => c.Id);
            Property(c => c.Code).HasMaxLength(ConstantManager.CodePropertyLength);
            Property(c => c.Name).HasMaxLength(ConstantManager.NamePropertyLength);
            HasMany(c => c.ItemEntities).WithRequired().HasForeignKey(c => c.ItemCategoryId);
        }
    }
}
