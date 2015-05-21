using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class CategoryEntityConfiguration : EntityTypeConfiguration<CategoryEntity>
    {
        public CategoryEntityConfiguration()
        {
            ToTable("Category");
            HasKey(c => c.CategoryId);
            Property(c => c.CategoryName).HasMaxLength(64).IsRequired();
            //Property(c => c.Color).HasMaxLength(ConstantManager.ColorPropertyLength).IsRequired();
            //Property(c => c.ImagePath).HasMaxLength(ConstantManager.ImagePathPropertyLength).IsRequired();
            //Property(c => c.ToolTip).HasMaxLength(ConstantManager.ToolTipPropertyLength).IsOptional();
            //Property(c => c.PathToLoad).HasMaxLength(ConstantManager.PathToLoadPropertyLength).IsRequired();
            //HasMany(c => c.SubModuleEntities).WithRequired().HasForeignKey(c => c.ModuleId);
            //MapToStoredProcedures();
        }
    }
}
