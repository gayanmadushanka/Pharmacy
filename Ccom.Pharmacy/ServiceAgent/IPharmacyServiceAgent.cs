using System;
using Ccom.Pharmacy.PharmacyService;

namespace Ccom.Pharmacy.ServiceAgent
{
    public interface IPharmacyServiceAgent
    {
        void InitializeExceptionAndLogging(EventHandler<InitializeExceptionAndLoggingCompletedEventArgs> callback);

        void GetUserDetailsByPasswordUsername(string userName, string password, EventHandler<GetUserDetailsByPasswordUsernameCompletedEventArgs> callback);
        void GetModulesByUserRoleId(int userRoleId, EventHandler<GetModulesByUserRoleIdCompletedEventArgs> callback);
        void GetModules(UserEntity userEntity, EventHandler<GetModulesCompletedEventArgs> callback);
        void GetAllModules(EventHandler<GetAllModulesCompletedEventArgs> callback);
        void GetAllUserDetails(EventHandler<GetAllUserDetailsCompletedEventArgs> callback);
        void GetUserRoles(EventHandler<GetUserRolesCompletedEventArgs> callback);

        #region Item Functions
        void GetItemById(int id, EventHandler<GetItemByIdCompletedEventArgs> callback);
        void GetAllItem(EventHandler<GetAllItemCompletedEventArgs> callback);
        void AddUpdateItem(ItemEntity itemEntity, EventHandler<AddUpdateItemCompletedEventArgs> callback);
        void DeleteItem(int id, EventHandler<DeleteItemCompletedEventArgs> callback);
        #endregion

        #region Supplier Functions
        void GetSupplierById(int id, EventHandler<GetSupplierByIdCompletedEventArgs> callback);
        void GetAllSupplier(EventHandler<GetAllSupplierCompletedEventArgs> callback);
        void AddUpdateSupplier(SupplierEntity supplierEntity, EventHandler<AddUpdateSupplierCompletedEventArgs> callback);
        void DeleteSupplier(int id, EventHandler<DeleteSupplierCompletedEventArgs> callback);
        #endregion

        #region Invoice Functions
        void GetInvoiceById(int id, EventHandler<GetInvoiceByIdCompletedEventArgs> callback);
        void GetAllInvoice(EventHandler<GetAllInvoiceCompletedEventArgs> callback);
        void AddUpdateInvoice(InvoiceEntity invoiceEntity, EventHandler<AddUpdateInvoiceCompletedEventArgs> callback);
        void DeleteInvoice(int id, EventHandler<DeleteInvoiceCompletedEventArgs> callback);
        void PrintInvoice(InvoiceEntity invoice, EventHandler<PrintInvoiceCompletedEventArgs> callback);
        #endregion

        #region InvoiceItem Functions
        void GetInvoiceItemById(int id, EventHandler<GetInvoiceItemByIdCompletedEventArgs> callback);
        void GetAllInvoiceItem(EventHandler<GetAllInvoiceItemCompletedEventArgs> callback);
        void AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity, EventHandler<AddUpdateInvoiceItemCompletedEventArgs> callback);
        void DeleteInvoiceItem(int id, EventHandler<DeleteInvoiceItemCompletedEventArgs> callback);
        #endregion

        #region ItemCategory Functions
        void GetItemCategoryById(int id, EventHandler<GetItemCategoryByIdCompletedEventArgs> callback);
        void GetAllItemCategory(EventHandler<GetAllItemCategoryCompletedEventArgs> callback);
        void AddUpdateItemCategory(ItemCategoryEntity itemCategoryEntity, EventHandler<AddUpdateItemCategoryCompletedEventArgs> callback);
        void DeleteItemCategory(int id, EventHandler<DeleteItemCategoryCompletedEventArgs> callback);
        #endregion
    }
}
