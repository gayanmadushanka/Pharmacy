using IOS.HMS.KIOSK.ServiceDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.HMS.KIOSK.ServiceDAL.Configurations
{
   public class LogEntityConfiguration : EntityTypeConfiguration<LogEntity>
    {
       public LogEntityConfiguration()
        {
            ToTable("Log");
            HasKey(c => c.LogId);
            Property(c => c.EventId);
            Property(c => c.Priority);
            Property(c => c.Severity).HasMaxLength(32);
            Property(c => c.Title).HasMaxLength(256);
            Property(c => c.Timestamp);
            Property(c => c.MachineName).HasMaxLength(32);
            Property(c => c.AppDomainName).HasMaxLength(512);
            Property(c => c.ProcessId).HasMaxLength(256);
            Property(c => c.ProcessName).HasMaxLength(512);
            Property(c => c.ThreadName).HasMaxLength(512);
            Property(c => c.Win32ThreadId).HasMaxLength(128);
            Property(c => c.Message).HasMaxLength(1500);
            Property(c => c.FormattedMessage);
            //HasMany(c => c.CategoryEntities).WithMany().Map(c => { c.ToTable("CategoryLog"); c.MapLeftKey(ConstantManager.UserRoleWithModuleLeftColumn); c.MapRightKey(ConstantManager.UserRoleWithModuleRightColumn); });
            //HasMany(c => c.SubModuleEntities).WithMany().Map(c => { c.ToTable(ConstantManager.UserRoleWithSubModuleTableName); c.MapLeftKey(ConstantManager.UserRoleWithSubModuleLeftColumn); c.MapRightKey(ConstantManager.UserRoleWithSubModuleRightColumn); });
            //HasMany(c => c.UserEntities).WithRequired().HasForeignKey(c => c.UserRoleId);
            //MapToStoredProcedures();
        }
    }
}
