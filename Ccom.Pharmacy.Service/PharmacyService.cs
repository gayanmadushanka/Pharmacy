using Ccom.Pharmacy.API;
using System.Collections.Generic;
using Ccom.Pharmacy.DAL.Entity;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Ccom.Pharmacy.Service
{
    public class PharmacyService : IPharmacyService
    {
        //static PharmacyService()
        //{
        //    InitializeExceptionAndLogging();
        //}

        public bool InitializeExceptionAndLogging()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);

            DatabaseProviderFactory databaseProviderFactory = new DatabaseProviderFactory(config);
            DatabaseFactory.SetDatabaseProviderFactory(databaseProviderFactory);

            LogWriterFactory logWriterFactory = new LogWriterFactory(config);
            Logger.SetLogWriter(logWriterFactory.Create());
            ExceptionPolicy.SetExceptionManager(factory.CreateManager());
            return true;
        }

        //public List<CustomerEntity> GetAllCustomer()
        //{
        //    return PharmacyAPI.GetAllCustomer();
        //}

        #region Item Functions
        public ItemEntity GetItemById(int id)
        {
            return PharmacyAPI.GetItemById(id);
        }

        public List<ItemEntity> GetAllItem()
        {
            return PharmacyAPI.GetAllItem();
        }

        public int AddUpdateItem(ItemEntity itemEntity)
        {
            return PharmacyAPI.AddUpdateItem(itemEntity);
        }

        public bool DeleteItem(int id)
        {
            return PharmacyAPI.DeleteItem(id);
        }
        #endregion

        #region Supplier Functions
        public SupplierEntity GetSupplierById(int id)
        {
            return PharmacyAPI.GetSupplierById(id);
        }

        public List<SupplierEntity> GetAllSupplier()
        {
            return PharmacyAPI.GetAllSupplier();
        }

        public int AddUpdateSupplier(SupplierEntity supplierEntity)
        {
            return PharmacyAPI.AddUpdateSupplier(supplierEntity);
        }

        public bool DeleteSupplier(int id)
        {
            return PharmacyAPI.DeleteItem(id);
        }
        #endregion

        #region Invoice Functions
        public InvoiceEntity GetInvoiceById(int id)
        {
            return PharmacyAPI.GetInvoiceById(id);
        }

        public List<InvoiceEntity> GetAllInvoice()
        {
            return PharmacyAPI.GetAllInvoice();
        }

        public int AddUpdateInvoice(InvoiceEntity itemEntity)
        {
            return PharmacyAPI.AddUpdateInvoice(itemEntity);
        }

        public bool DeleteInvoice(int id)
        {
            return PharmacyAPI.DeleteInvoice(id);
        }

        public bool PrintInvoice(InvoiceEntity invoice)
        {
            return PharmacyAPI.PrintInvoice(invoice);
        }

        #endregion

        #region InvoiceItem Functions
        public InvoiceItemEntity GetInvoiceItemById(int id)
        {
            return PharmacyAPI.GetInvoiceItemById(id);
        }

        public List<InvoiceItemEntity> GetAllInvoiceItem()
        {
            return PharmacyAPI.GetAllInvoiceItem();
        }

        public int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity)
        {
            return PharmacyAPI.AddUpdateInvoiceItem(invoiceItemEntity);
        }

        public bool DeleteInvoiceItem(int id)
        {
            return PharmacyAPI.DeleteInvoiceItem(id);
        }
        #endregion

        #region Item Category Functions
        public ItemCategoryEntity GetItemCategoryById(int id)
        {
            return PharmacyAPI.GetItemCategoryById(id);
        }

        public List<ItemCategoryEntity> GetAllItemCategory()
        {
            return PharmacyAPI.GetAllItemCategory();
        }

        public int AddUpdateItemCategory(ItemCategoryEntity itemEntity)
        {
            return PharmacyAPI.AddUpdateItemCategory(itemEntity);
        }

        public bool DeleteItemCategory(int id)
        {
            return PharmacyAPI.DeleteItemCategory(id);
        }
        #endregion

        public UserEntity GetUserDetailsByPasswordUsername(string userName, string password)
        {
            return PharmacyAPI.GetUserDetailsByPasswordUsername(userName, password);
        }

        public List<ModuleEntity> GetModules(UserEntity userEntity)
        {
            return PharmacyAPI.GetModules(userEntity);
        }

        public UserEntity GetUserDetailsBy(int id)
        {
            return PharmacyAPI.GetUserDetailsBy(x => x.Id == id);
        }

        public int AddUpdateUserDetails(UserEntity userDetails)
        {
            return PharmacyAPI.AddUpdateUserDetails(userDetails);
        }

        public bool ForgotPassword(UserEntity userDetails)
        {
            return PharmacyAPI.ForgotPassword(userDetails);
        }

        //public List<SubModuleEntity> GetSubModulesBy(Expression<Func<SubModuleEntity, bool>> selector)
        //{
        //    return PharmacyAPI.GetSubModulesBy(selector);
        //}

        public List<UserEntity> GetAllUserDetails()
        {
            return PharmacyAPI.GetAllUserDetails();
        }

        public List<UserRoleEntity> GetUserRoles()
        {
            return PharmacyAPI.GetUserRoles();
        }

        public List<UserRoleEntity> GetModulesByUserRoleId(int userRoleId)
        {
            return PharmacyAPI.GetModulesByUserRoleId(userRoleId);
        }

        //public List<UserCategoryEntity> GetUserCategories()
        //{
        //    return PharmacyAPI.GetUserCategories();
        //}

        public List<ModuleEntity> GetAllModules()
        {
            return PharmacyAPI.GetAllModules();
        }

        //public List<SubModuleEntity> GetAllSubModules()
        //{
        //    return PharmacyAPI.GetAllSubModules();
        //}

        public bool DeleteUserDetails(int id)
        {
            return PharmacyAPI.DeleteUserDetails(id);
        }

        //public List<LogEntity> GetLogDetailsBy(Expression<Func<LogEntity, bool>> selector = null)
        //{
        //    return PharmacyAPI.GetLogDetailsBy(selector);
        //}

        //public bool DeleteLog(int id)
        //{
        //    return PharmacyAPI.DeleteLog(id);
        //}
    }
}
