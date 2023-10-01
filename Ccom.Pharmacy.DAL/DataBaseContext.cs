using System.Data.Entity;
using System.Transactions;
using Ccom.Pharmacy.DAL.Configurations;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Migrations;

namespace Ccom.Pharmacy.DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<CustomerEntity> CustomerDbSet { get; set; }
        public virtual DbSet<InvoiceEntity> InvoiceDbSet { get; set; }
        public virtual DbSet<InvoiceItemEntity> InvoiceItemDbSet { get; set; }
        public virtual DbSet<ItemEntity> ItemDbSet { get; set; }
        public virtual DbSet<SupplierEntity> SupplierDbSet { get; set; }
        public virtual DbSet<ItemCategoryEntity> ItemCategoryDbSet { get; set; }
        public virtual DbSet<UserEntity> UserDbSet { get; set; }
        public virtual DbSet<ModuleEntity> ModuleDbSet { get; set; }
        public virtual DbSet<UserRoleEntity> UserRoleDbSet { get; set; }
        //public DbSet<UserCategoryEntity> UserCategoryDbSet { get; set; }
        //public DbSet<CategoryEntity> Categories { get; set; }
        //public DbSet<CategoryLog> CategoryLogs { get; set; }
        //public DbSet<LogEntity> Logs { get; set; }

        public DataBaseContext()
            : base("PharmacySqlDbContext")
        //: base("Data Source=MADUSHANKA-PC;Initial Catalog=PharmacyDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Configuration>("PharmacySqlDbContext"));

            Database.SetInitializer<DataBaseContext>(null);

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoiceItemConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new ItemCategoryConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());

            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            //modelBuilder.Configurations.Add(new UserCategoryEntityConfiguration());

            modelBuilder.Configurations.Add(new ModuleEntityConfiguration());
            modelBuilder.Configurations.Add(new UserRoleEntityConfiguration());

            //modelBuilder.Configurations.Add(new SubModuleEntityConfiguration());

            //modelBuilder.Entity<CategoryEntity>()
            //   .HasMany(e => e.CategoryLogs)
            //   .WithRequired(e => e.Category)
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<LogEntity>()
            //    .HasMany(e => e.CategoryLogs)
            //    .WithRequired(e => e.Log)
            //    .WillCascadeOnDelete(true);
        }

        public virtual void Commit()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                base.SaveChanges();
                transaction.Complete();
            }
        }

        public virtual void ProxyCreation(bool isEnable)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
