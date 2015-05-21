using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class InvoiceConfiguration : EntityTypeConfiguration<InvoiceEntity>
    {
        public InvoiceConfiguration()
        {
            ToTable(ConstantManager.InvoiceTableName);
            HasKey(c => c.Id);
            Property(c => c.InvoiceNo).HasMaxLength(ConstantManager.AccountNumberPropertyLength);
            Property(c => c.TotalAmount);
            Property(c => c.SubAmount);
            Property(c => c.Cash);
            Property(c => c.Balance);
            Property(c => c.Discount);
            Property(c => c.Description).HasMaxLength(ConstantManager.DescriptionPropertyLength);
            Property(c => c.Date);
            HasMany(c => c.InvoiceItemEntities).WithRequired().HasForeignKey(c => c.InvoiceId);
        }
    }
}
