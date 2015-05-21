using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Managers;

namespace Ccom.Pharmacy.DAL.Configurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserEntityConfiguration()
        {
            ToTable(ConstantManager.UserTableName);
            HasKey(c => c.Id);
            Property(c => c.FirstName).HasMaxLength(ConstantManager.NamePropertyLength).IsRequired();
            Property(c => c.LastName).HasMaxLength(ConstantManager.NamePropertyLength).IsOptional();
            Property(c => c.MiddleName).HasMaxLength(ConstantManager.NamePropertyLength).IsOptional();
            Property(c => c.UserName).HasMaxLength(ConstantManager.NamePropertyLength).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute(ConstantManager.IndexNameForUserName) { IsUnique = true } }));
            Property(c => c.Password).HasMaxLength(ConstantManager.PasswordPropertyLength).IsRequired();
            //Property(c => c.UserName).HasMaxLength(ConstantManager.NamePropertyLength).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute(ConstantManager.IndexNameForUserName) { IsUnique = true }, new IndexAttribute(ConstantManager.IndexNameForUserNamePassword, 1) { IsUnique = true } }));
            //Property(c => c.Password).HasMaxLength(ConstantManager.PasswordPropertyLength).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute(ConstantManager.IndexNameForPassword) { IsUnique = true }, new IndexAttribute(ConstantManager.IndexNameForUserNamePassword, 2) { IsUnique = true } }));
            Property(c => c.Address).HasMaxLength(ConstantManager.AddressPropertyLength).IsOptional();
            Property(c => c.HomeNumber).HasMaxLength(ConstantManager.ContactNumberPropertyLength).IsOptional();
            Property(c => c.OfficeNumber).HasMaxLength(ConstantManager.ContactNumberPropertyLength).IsOptional();
            Property(c => c.MobileNumber).HasMaxLength(ConstantManager.ContactNumberPropertyLength).IsRequired();
            Property(c => c.Email).HasMaxLength(ConstantManager.EmailPropertyLength).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute(ConstantManager.IndexNameForEmail) { IsUnique = true } }));
            Property(c => c.ImagePath).HasMaxLength(ConstantManager.ImagePathPropertyLength).IsOptional();

            HasRequired(c => c.UserRole);
            //HasRequired(c => c.UserCategory);
            //MapToStoredProcedures();
        }
    }
}
