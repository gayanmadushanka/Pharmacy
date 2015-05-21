using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<CustomerEntity>
    {
        public CustomerConfiguration()
        {
            ToTable(ConstantManager.CustomerTableName);
            HasKey(c => c.Id);
            Property(c => c.Name).HasMaxLength(ConstantManager.NamePropertyLength);
            Property(c => c.Address).HasMaxLength(ConstantManager.AddressPropertyLength);
            Property(c => c.ContactNumber).HasMaxLength(ConstantManager.ContactNumberPropertyLength);
        }
    }
}
