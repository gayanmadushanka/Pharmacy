using System;
using System.Collections.ObjectModel;
using Ccom.Pharmacy.DAL.Entity;
using MySql.Data.Entity;

namespace Ccom.Pharmacy.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(DataBaseContext context)
        {
            context.UserDbSet.AddOrUpdate(
                p => p.UserName,
                //1
                new UserEntity()
                {
                    FirstName = "Admin User",
                    UserName = "a",
                    Password = "/NNfWRStbZsUyc88S5tjhA==",
                    Email = "admin@mail.com",
                    MobileNumber = "0712222222",
                    ImagePath = "/Images/userdefault.png",
                    UserRole = new UserRoleEntity()
                    {
                        Name = "Admin User",
                        Description = "Admin User",
                        ModuleEntities = GetAdminModuleEntities()
                    }
                }
                //,
                //2
                //new UserEntity()
                //{
                //    FirstName = "Typical User",
                //    UserName = "d",
                //    Password = "zXdVUpC4anLlM9Fxp9jRuQ==",
                //    Email = "typical@mail.com",
                //    MobileNumber = "0712222222",
                //    ImagePath = "/Images/profile.png",
                //    UserRole = new UserRoleEntity()
                //    {
                //        Name = "Typical User",
                //        Description = "Typical User"
                //        //,
                //        //ModuleEntities = GetTypicalUserModuleEntities()
                //    }
                //}
            );

            //1
            context.ItemCategoryDbSet.AddOrUpdate(
                p => p.Name,
                GetItemCategoryEntity("Pain Relief"),
                GetItemCategoryEntity("Stop Smoking"),
                GetItemCategoryEntity("Weight Loss")
            );

            context.SupplierDbSet.AddOrUpdate(
                p => p.FirstName,
                new SupplierEntity
                {
                    FirstName = "Gayan",
                    LastName = "Madushanka",
                    AccountNumber = "123",
                    Address = "Anuradhapura",
                    ContactNumber = "0252225955"
                },
              new SupplierEntity
              {
                  FirstName = "Wasana",
                  LastName = "Dilhani",
                  AccountNumber = "123",
                  Address = "Kandy",
                  ContactNumber = "0812225955"
              }
            );

            //2
            //context.ItemDbSet.AddOrUpdate(
            //    p => p.Name,
            //    new ItemEntity
            //    {
            //        Name = "ACCUTANE",
            //        ActualPrice = 35.99,
            //        ItemCategoryId = 1,
            //        Description = "",
            //        Discount = 5.00,
            //        Quantity = 10,
            //        SupplierId = 2
            //    }
            //    ,
            //     new ItemEntity
            //     {
            //         Name = "DIFFERIN",
            //         ActualPrice = 83.99,
            //         ItemCategoryId = 2,
            //         Description = "Avoid",
            //         Discount = 5.00,
            //         Quantity = 8,
            //         SupplierId = 1
            //     }
            //     ,
            //     new ItemEntity
            //     {
            //         Name = "Oil",
            //         ActualPrice = 97.99,
            //         ItemCategoryId = 1,
            //         Description = "fgfg",
            //         Discount = 5.00,
            //         Quantity = 8,
            //         SupplierId = 1
            //     }
            // );

            //context.InvoiceDbSet.AddOrUpdate(
            //    p => p.Amount,
            //    new InvoiceEntity
            //    {
            //        Amount = 400.00,
            //        Date = DateTime.Now,
            //        InvoiceItemEntities = new Collection<InvoiceItemEntity>
            //        {
            //            new InvoiceItemEntity()
            //        }
            //    });
        }

        private static Collection<ModuleEntity> GetTypicalUserModuleEntities()
        {
            return new Collection<ModuleEntity>
            { 
                GetModuleEntity("Cashier","Ccom.Pharmacy.Views.CashierScreenView")
            };
        }

        private static Collection<ModuleEntity> GetAdminModuleEntities()
        {
            return new Collection<ModuleEntity>
            { 
                GetModuleEntity("Invoice","Ccom.Pharmacy.Views.InvoiceView"),
                GetModuleEntity("Item","Ccom.Pharmacy.Views.ItemView"),
                GetModuleEntity("Supplier","Ccom.Pharmacy.Views.SupplierView"),
                GetModuleEntity("Item Category","Ccom.Pharmacy.Views.ItemCategoryView"),
                GetModuleEntity("Authentication","Ccom.Pharmacy.Views.AuthenticationView"),
                GetModuleEntity("Customer","Ccom.Pharmacy.Views.CustomerView"),
                GetModuleEntity("Report","Ccom.Pharmacy.Views.ReportView"),
                GetModuleEntity("Cashier","Ccom.Pharmacy.Views.CashierScreenView")
            };
        }

        private static ModuleEntity GetModuleEntity(string name, string pathToLoad)
        {
            return new ModuleEntity { Name = name, Color = "#e8781a", ImagePath = "fa fa-user", ToolTip = name, PathToLoad = pathToLoad };
        }

        private static ItemCategoryEntity GetItemCategoryEntity(string name)
        {
            return new ItemCategoryEntity { Name = name };
        }

        ////private static Collection<ItemEntity> GetGayanItemEntities()
        ////{
        ////    return new Collection<ItemEntity>
        ////    {
        ////        new ItemEntity
        ////        {
        ////            Name = "ACCUTANE (ISOTRETINOIN) ROACCUTANE 10mg 30tbs",
        ////            ActualPrice = 35.99,
        ////            ItemCategory = GetItemCategoryEntity("Pain Relief"),
        ////            Description = "",
        ////            Discount = 5.00,
        ////            Quantity = 10
        ////        },
        ////        new ItemEntity
        ////        {
        ////            Name = "DIFFERIN (ADAPALENE) 0.10 GEL 30 grams gel",
        ////            ActualPrice = 83.99,
        ////            ItemCategory = GetItemCategoryEntity("Stop Smoking"),
        ////            Description = "Avoid prolonged exposure to sunlight. Differin may increase the sensitivity of your skin to sunlight. Use a sunscreen and wear protective clothing when sun exposure is unavoidable. Do not use adapalene on sunburned, windburned, dry, chapped, or irritated skin or on open wounds. Avoid abrasive, harsh, or drying soaps and cleansers while using differin.",
        ////            Discount = 5.00,
        ////            Quantity = 8
        ////        }
        ////    };
        ////}

        ////private static Collection<ItemEntity> GetWasanaItemEntities()
        ////{
        ////    return new Collection<ItemEntity>
        ////    {
        ////        new ItemEntity
        ////        {
        ////            Name = "ACCUTANE (ISOTRETINOIN) ROACCUTANE 10mg 30tbs",
        ////            ActualPrice = 35.99,
        ////            ItemCategory = GetItemCategoryEntity("Weight Loss"),
        ////            Description = "",
        ////            Discount = 5.00,
        ////            Quantity = 10
        ////        },
        ////        new ItemEntity
        ////        {
        ////            Name = "DIFFERIN (ADAPALENE) 0.10 GEL 30 grams gel",
        ////            ActualPrice = 83.99,
        ////            ItemCategory = GetItemCategoryEntity("Stop Smoking"),
        ////            Description = "Avoid prolonged exposure to sunlight. Differin may increase the sensitivity of your skin to sunlight. Use a sunscreen and wear protective clothing when sun exposure is unavoidable. Do not use adapalene on sunburned, windburned, dry, chapped, or irritated skin or on open wounds. Avoid abrasive, harsh, or drying soaps and cleansers while using differin.",
        ////            Discount = 5.00,
        ////            Quantity = 18
        ////        }
        ////    };
        ////}
    }
}
