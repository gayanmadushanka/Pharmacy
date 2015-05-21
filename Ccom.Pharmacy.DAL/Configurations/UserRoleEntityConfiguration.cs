using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class UserRoleEntityConfiguration : EntityTypeConfiguration<UserRoleEntity>
    {
        public UserRoleEntityConfiguration()
        {
            ToTable(ConstantManager.UserRoleTableName);
            HasKey(c => c.Id);
            Property(c => c.Name).HasMaxLength(ConstantManager.NamePropertyLength).IsRequired();
            Property(c => c.Description).HasMaxLength(ConstantManager.DescriptionPropertyLength).IsOptional();
            Property(c => c.ImagePath).HasMaxLength(ConstantManager.ImagePathPropertyLength).IsOptional();
            HasMany(c => c.ModuleEntities).WithMany().Map(c => { c.ToTable(ConstantManager.UserRoleWithModuleTableName); c.MapLeftKey(ConstantManager.UserRoleWithModuleLeftColumn); c.MapRightKey(ConstantManager.UserRoleWithModuleRightColumn); });
            //HasMany(c => c.SubModuleEntities).WithMany().Map(c => { c.ToTable(ConstantManager.UserRoleWithSubModuleTableName); c.MapLeftKey(ConstantManager.UserRoleWithSubModuleLeftColumn); c.MapRightKey(ConstantManager.UserRoleWithSubModuleRightColumn); });
            HasMany(c => c.UserEntities).WithRequired().HasForeignKey(c => c.UserRoleId);
            //MapToStoredProcedures();
        }
    }
}
