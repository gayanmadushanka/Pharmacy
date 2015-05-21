using System.Collections.Generic;
using System.ServiceModel;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.Service
{
    [ServiceContract]
    public interface IPharmacyService
    {
        [OperationContract]
        bool InitializeExceptionAndLogging();

        //[OperationContract]
        //List<CustomerEntity> GetAllCustomer();

        #region Item Functions
        [OperationContract]
        ItemEntity GetItemById(int id);

        [OperationContract]
        List<ItemEntity> GetAllItem();

        [OperationContract]
        int AddUpdateItem(ItemEntity itemEntity);

        [OperationContract]
        bool DeleteItem(int id);
        #endregion

        #region Supplier Functions
        [OperationContract]
        SupplierEntity GetSupplierById(int id);

        [OperationContract]
        List<SupplierEntity> GetAllSupplier();

        [OperationContract]
        int AddUpdateSupplier(SupplierEntity supplierEntity);

        [OperationContract]
        bool DeleteSupplier(int id);
        #endregion

        #region Invoice Functions
        [OperationContract]
        InvoiceEntity GetInvoiceById(int id);

        [OperationContract]
        List<InvoiceEntity> GetAllInvoice();

        [OperationContract]
        int AddUpdateInvoice(InvoiceEntity invoiceEntity);

        [OperationContract]
        bool DeleteInvoice(int id);

        [OperationContract]
        bool PrintInvoice(InvoiceEntity invoice);
        #endregion

        #region InvoiceItem Functions
        [OperationContract]
        InvoiceItemEntity GetInvoiceItemById(int id);

        [OperationContract]
        List<InvoiceItemEntity> GetAllInvoiceItem();

        [OperationContract]
        int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity);

        [OperationContract]
        bool DeleteInvoiceItem(int id);
        #endregion

        #region ItemCategory Functions
        [OperationContract]
        ItemCategoryEntity GetItemCategoryById(int id);

        [OperationContract]
        List<ItemCategoryEntity> GetAllItemCategory();

        [OperationContract]
        int AddUpdateItemCategory(ItemCategoryEntity itemCategoryEntity);

        [OperationContract]
        bool DeleteItemCategory(int id);
        #endregion

        [OperationContract]
        UserEntity GetUserDetailsByPasswordUsername(string userName, string password);

        [OperationContract]
        List<ModuleEntity> GetModules(UserEntity userEntity);

        [OperationContract]
        UserEntity GetUserDetailsBy(int id);

        [OperationContract]
        int AddUpdateUserDetails(UserEntity userDetails);

        [OperationContract]
        bool ForgotPassword(UserEntity userDetails);

        //[OperationContract]
        //List<SubModuleEntity> GetSubModulesBy(Expression<Func<SubModuleEntity, bool>> selector);

        [OperationContract]
        List<UserEntity> GetAllUserDetails();

        [OperationContract]
        List<UserRoleEntity> GetUserRoles();

        [OperationContract]
        List<UserRoleEntity> GetModulesByUserRoleId(int userRoleId);

        //[OperationContract]
        //List<UserCategoryEntity> GetUserCategories();

        [OperationContract]
        List<ModuleEntity> GetAllModules();

        //[OperationContract]
        //List<SubModuleEntity> GetAllSubModules();

        [OperationContract]
        bool DeleteUserDetails(int id);

        //[OperationContract]
        //List<LogEntity> GetLogDetailsBy(Expression<Func<LogEntity, bool>> selector = null);

        //[OperationContract]
        //bool DeleteLog(int id);

    }
}
