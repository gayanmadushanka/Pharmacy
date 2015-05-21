using System;
using Ccom.Pharmacy.PharmacyService;

namespace Ccom.Pharmacy.ServiceAgent
{
    class PharmacyServiceAgent : IPharmacyServiceAgent
    {
        private PharmacyServiceClient _client = new PharmacyServiceClient();

        public void InitializeExceptionAndLogging(EventHandler<InitializeExceptionAndLoggingCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.InitializeExceptionAndLoggingCompleted += callback;
            _client.InitializeExceptionAndLoggingAsync();
        }

        public void GetUserDetailsByPasswordUsername(string userName, string password, EventHandler<GetUserDetailsByPasswordUsernameCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetUserDetailsByPasswordUsernameCompleted += callback;
            _client.GetUserDetailsByPasswordUsernameAsync(userName, password);
        }

        public void GetModulesByUserRoleId(int userRoleId, EventHandler<GetModulesByUserRoleIdCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetModulesByUserRoleIdCompleted += callback;
            _client.GetModulesByUserRoleIdAsync(userRoleId);
        }

        public void GetModules(UserEntity userEntity, EventHandler<GetModulesCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetModulesCompleted += callback;
            _client.GetModulesAsync(userEntity);
        }

        public void GetAllModules(EventHandler<GetAllModulesCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetAllModulesCompleted += callback;
            _client.GetAllModulesAsync();
        }

        public void GetAllUserDetails(EventHandler<GetAllUserDetailsCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetAllUserDetailsCompleted += callback;
            _client.GetAllUserDetailsAsync();
        }

        public void GetUserRoles(EventHandler<GetUserRolesCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetUserRolesCompleted += callback;
            _client.GetUserRolesAsync();
        }

        #region Item Functions
        public void GetItemById(int id, EventHandler<GetItemByIdCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetItemByIdCompleted += callback;
            _client.GetItemByIdAsync(id);
        }

        public void GetAllItem(EventHandler<GetAllItemCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetAllItemCompleted += callback;
            _client.GetAllItemAsync();
        }

        public void AddUpdateItem(ItemEntity itemEntity, EventHandler<AddUpdateItemCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.AddUpdateItemCompleted += callback;
            _client.AddUpdateItemAsync(itemEntity);
        }

        public void DeleteItem(int id, EventHandler<DeleteItemCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.DeleteItemCompleted += callback;
            _client.DeleteItemAsync(id);
        }
        #endregion

        #region Supplier Functions
        public void GetSupplierById(int id, EventHandler<GetSupplierByIdCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetSupplierByIdCompleted += callback;
            _client.GetSupplierByIdAsync(id);
        }

        public void GetAllSupplier(EventHandler<GetAllSupplierCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetAllSupplierCompleted += callback;
            _client.GetAllSupplierAsync();
        }

        public void AddUpdateSupplier(SupplierEntity supplierEntity, EventHandler<AddUpdateSupplierCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.AddUpdateSupplierCompleted += callback;
            _client.AddUpdateSupplierAsync(supplierEntity);
        }

        public void DeleteSupplier(int id, EventHandler<DeleteSupplierCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.DeleteSupplierCompleted += callback;
            _client.DeleteSupplierAsync(id);
        }
        #endregion

        #region Invoice Functions
        public void GetInvoiceById(int id, EventHandler<GetInvoiceByIdCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetInvoiceByIdCompleted += callback;
            _client.GetInvoiceByIdAsync(id);
        }

        public void GetAllInvoice(EventHandler<GetAllInvoiceCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetAllInvoiceCompleted += callback;
            _client.GetAllInvoiceAsync();
        }

        public void AddUpdateInvoice(InvoiceEntity invoiceEntity, EventHandler<AddUpdateInvoiceCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.AddUpdateInvoiceCompleted += callback;
            _client.AddUpdateInvoiceAsync(invoiceEntity);
        }

        public void DeleteInvoice(int id, EventHandler<DeleteInvoiceCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.DeleteInvoiceCompleted += callback;
            _client.DeleteInvoiceAsync(id);
        }

        public void PrintInvoice(InvoiceEntity invoice, EventHandler<PrintInvoiceCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.PrintInvoiceCompleted += callback;
            _client.PrintInvoiceAsync(invoice);
        }

        #endregion

        #region InvoiceItem Functions
        public void GetInvoiceItemById(int id, EventHandler<GetInvoiceItemByIdCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetInvoiceItemByIdCompleted += callback;
            _client.GetInvoiceItemByIdAsync(id);
        }

        public void GetAllInvoiceItem(EventHandler<GetAllInvoiceItemCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetAllInvoiceItemCompleted += callback;
            _client.GetAllInvoiceItemAsync();
        }

        public void AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity, EventHandler<AddUpdateInvoiceItemCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.AddUpdateInvoiceItemCompleted += callback;
            _client.AddUpdateInvoiceItemAsync(invoiceItemEntity);
        }

        public void DeleteInvoiceItem(int id, EventHandler<DeleteInvoiceItemCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.DeleteInvoiceItemCompleted += callback;
            _client.DeleteInvoiceItemAsync(id);
        }
        #endregion

        #region ItemCategory Functions
        public void GetItemCategoryById(int id, EventHandler<GetItemCategoryByIdCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetItemCategoryByIdCompleted += callback;
            _client.GetItemCategoryByIdAsync(id);
        }

        public void GetAllItemCategory(EventHandler<GetAllItemCategoryCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.GetAllItemCategoryCompleted += callback;
            _client.GetAllItemCategoryAsync();
        }

        public void AddUpdateItemCategory(ItemCategoryEntity itemCategory, EventHandler<AddUpdateItemCategoryCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.AddUpdateItemCategoryCompleted += callback;
            _client.AddUpdateItemCategoryAsync(itemCategory);
        }

        public void DeleteItemCategory(int id, EventHandler<DeleteItemCategoryCompletedEventArgs> callback)
        {
            _client = new PharmacyServiceClient();
            _client.DeleteItemCategoryCompleted += callback;
            _client.DeleteItemCategoryAsync(id);
        }
        #endregion
    }
}
