using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class InvoiceItemConfiguration : EntityTypeConfiguration<InvoiceItemEntity>
    {
        public InvoiceItemConfiguration()
        {
            ToTable(ConstantManager.InvoiceItemTableName);
            HasKey(c => c.Id);
            Property(c => c.Quantity);
            Property(c => c.TotalAmount);
            HasRequired(c => c.Invoice);
            HasRequired(l => l.Item).WithMany().HasForeignKey(l => l.ItemId);
        }
    }
}
