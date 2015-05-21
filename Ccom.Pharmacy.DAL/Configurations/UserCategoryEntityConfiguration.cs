using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class UserCategoryEntityConfiguration : EntityTypeConfiguration<UserCategoryEntity>
    {
        public UserCategoryEntityConfiguration()
        {
            ToTable(ConstantManager.UserCategoryTableName);
            HasKey(c => c.Id);
            Property(c => c.Name).HasMaxLength(ConstantManager.NamePropertyLength).IsRequired();
            Property(c => c.Description).HasMaxLength(ConstantManager.DescriptionPropertyLength).IsOptional();
            Property(c => c.ImagePath).HasMaxLength(ConstantManager.ImagePathPropertyLength).IsOptional();
            HasMany(c => c.UserEntities).WithOptional().HasForeignKey(c => c.UserCategoryId);
            //MapToStoredProcedures();
        }
    }
}
