using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class SupplierConfiguration : EntityTypeConfiguration<SupplierEntity>
    {
        public SupplierConfiguration()
        {
            ToTable(ConstantManager.SupplierTableName);
            HasKey(c => c.Id);
            Property(c => c.FirstName).HasMaxLength(ConstantManager.NamePropertyLength);
            Property(c => c.LastName).HasMaxLength(ConstantManager.NamePropertyLength);
            Property(c => c.Address).HasMaxLength(ConstantManager.AddressPropertyLength);
            Property(c => c.ContactNumber).HasMaxLength(ConstantManager.ContactNumberPropertyLength);
            Property(c => c.AccountNumber).HasMaxLength(ConstantManager.AccountNumberPropertyLength);
            HasMany(c => c.ItemEntities).WithRequired().HasForeignKey(c => c.SupplierId);
        }
    }
}
