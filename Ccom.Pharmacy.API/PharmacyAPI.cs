using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ccom.Pharmacy.BL;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.API
{
    public class PharmacyAPI
    {
        public static List<RoomChargeForReporting> GetRoomChargeList(int branchId, DateTime startDate, DateTime endDate)
        {
            List<RoomChargeForReporting> roomChargeForReportingList = new List<RoomChargeForReporting>();
            for (int i = 0; i < 113; i++)
            {
                RoomChargeForReporting roomChargeForReporting = new RoomChargeForReporting();
                roomChargeForReporting.InvNo = "INV0000035";
                roomChargeForReporting.RegDate = DateTime.Now;
                roomChargeForReporting.InvAmount = 1200;
                roomChargeForReporting.GuestName = "Gayan";
                roomChargeForReportingList.Add(roomChargeForReporting);
            }

            return roomChargeForReportingList;
        }

        #region Customer Functions

        public static CustomerEntity GetCustomerById(int id)
        {
            return CustomerBL.GetCustomerById(id);
        }

        public static async Task<List<CustomerEntity>> GetAllCustomerAsync()
        {
            return CustomerBL.GetAllCustomer();
        }

        public static async Task<int> AddUpdateCustomerAsync(CustomerEntity customerEntity)
        {
            return CustomerBL.AddUpdateCustomer(customerEntity);
        }

        public static async Task<bool> DeleteCustomerAsync(int id)
        {
            return CustomerBL.DeleteCustomer(id);
        }

        #endregion

        #region Item Functions

        public static ItemEntity GetItemById(int id)
        {
            return ItemBL.GetItemById(id);
        }

        public static async Task<List<ItemEntity>> GetAllItemAsync()
        {
            return ItemBL.GetAllItem();
        }

        public static List<ItemEntity> GetAllItem()
        {
            return ItemBL.GetAllItem();
        }

        public static async Task<int> AddUpdateItemAsync(ItemEntity itemEntity)
        {
            return ItemBL.AddUpdateItem(itemEntity);
        }

        public static int AddUpdateItem(ItemEntity itemEntity)
        {
            return ItemBL.AddUpdateItem(itemEntity);
        }

        public static async Task<bool> DeleteItemAsync(int id)
        {
            return ItemBL.DeleteItem(id);
        }

        public static bool DeleteItem(int id)
        {
            return ItemBL.DeleteItem(id);
        }

        #endregion

        #region Supplier Functions

        public static SupplierEntity GetSupplierById(int id)
        {
            return SupplierBL.GetSupplierById(id);
        }

        public static async Task<List<SupplierEntity>> GetAllSupplierAsync()
        {
            return SupplierBL.GetAllSupplier();
        }

        public static List<SupplierEntity> GetAllSupplier()
        {
            return SupplierBL.GetAllSupplier();
        }

        public static async Task<int> AddUpdateSupplierAsync(SupplierEntity supplierEntity)
        {
            return SupplierBL.AddUpdateSupplier(supplierEntity);
        }

        public static int AddUpdateSupplier(SupplierEntity supplierEntity)
        {
            return SupplierBL.AddUpdateSupplier(supplierEntity);
        }

        public static async Task<bool> DeleteSupplierAsync(int id)
        {
            return SupplierBL.DeleteSupplier(id);
        }

        #endregion

        #region Invoice Functions

        public static InvoiceEntity GetInvoiceById(int id)
        {
            return InvoiceBL.GetInvoiceById(id);
        }

        public static async Task<List<InvoiceEntity>> GetAllInvoiceAsync()
        {
            return InvoiceBL.GetAllInvoice();
        }

        public static  List<InvoiceEntity> GetAllInvoice()
        {
            return InvoiceBL.GetAllInvoice();
        }

        public static async Task<int> AddUpdateInvoiceAsync(InvoiceEntity invoiceEntity)
        {
            return InvoiceBL.AddUpdateInvoice(invoiceEntity);
        }


        public static int AddUpdateInvoice(InvoiceEntity invoiceEntity)
        {
            return InvoiceBL.AddUpdateInvoice(invoiceEntity);
        }

        public static async Task<bool> DeleteInvoiceAsync(int id)
        {
            return InvoiceBL.DeleteInvoice(id);
        }

        public static bool DeleteInvoice(int id)
        {
            return InvoiceBL.DeleteInvoice(id);
        }

        public static string GetInvoiceNo()
        {
            return InvoiceBL.GetInvoiceNo();
        }

        //public static async Task<string> GetInvoiceNo()
        //{
        //    return InvoiceBL.GetInvoiceNo();
        //}

        public static bool PrintInvoice(InvoiceEntity invoice)
        {
            return InvoiceBL.PrintInvoice(invoice);
        }

        //public static async Task<bool> PrintInvoiceAsync(InvoiceEntity invoice)
        //{
        //    return InvoiceBL.PrintInvoice(invoice);
        //}

        public static List<InvoiceEntity> GetInvoiceDetailsByDateRange(ReportingEntity reportingEntity)
        {
            return InvoiceBL.GetInvoiceDetailsByDateRange(reportingEntity);
        }
        #endregion

        #region InvoiceItem Functions

        public static async Task<InvoiceItemEntity> GetInvoiceItemByIdAsync(int id)
        {
            return InvoiceItemBL.GetInvoiceItemById(id);
        }

        public static InvoiceItemEntity GetInvoiceItemById(int id)
        {
            return InvoiceItemBL.GetInvoiceItemById(id);
        }

        public static List<InvoiceItemEntity> GetAllInvoiceItem()
        {
            return InvoiceItemBL.GetAllInvoiceItem();
        }

        public static List<InvoiceItemEntity> GetInvoiceItemByInvoiceId(int invoiceId)
        {
            return InvoiceItemBL.GetInvoiceItemByInvoiceId(invoiceId);
        }

        public static async Task<List<InvoiceItemEntity>> GetInvoiceItemByInvoiceIdAsync(int invoiceId)
        {
            return InvoiceItemBL.GetInvoiceItemByInvoiceId(invoiceId);
        }

        public static int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity)
        {
            return InvoiceItemBL.AddUpdateInvoiceItem(invoiceItemEntity);
        }

        public static bool DeleteInvoiceItem(int id)
        {
            return InvoiceItemBL.DeleteInvoiceItem(id);
        }

        #endregion

        #region ItemCategory Functions

        public static ItemCategoryEntity GetItemCategoryById(int id)
        {
            return ItemCategoryBL.GetItemCategoryById(id);
        }

        public static async Task<List<ItemCategoryEntity>> GetAllItemCategoryAsync()
        {
            return ItemCategoryBL.GetAllItemCategory();
        }

        public static List<ItemCategoryEntity> GetAllItemCategory()
        {
            return ItemCategoryBL.GetAllItemCategory();
        }

        public static async Task<int> AddUpdateItemCategoryAsync(ItemCategoryEntity itemCategoryEntity)
        {
            return ItemCategoryBL.AddUpdateItemCategory(itemCategoryEntity);
        }

        public static int AddUpdateItemCategory(ItemCategoryEntity itemCategoryEntity)
        {
            return ItemCategoryBL.AddUpdateItemCategory(itemCategoryEntity);
        }

        public static async Task<bool> DeleteItemCategoryAsync(int id)
        {
            return ItemCategoryBL.DeleteItemCategory(id);
        }


        public static bool DeleteItemCategory(int id)
        {
            return ItemCategoryBL.DeleteItemCategory(id);
        }

        #endregion

        public static async Task<UserEntity> GetUserDetailsByPasswordUsernameAsync(string userName, string password)
        {
            return UserDetailBL.GetUserDetailsByPasswordUsername(userName, password);
        }

        public static UserEntity GetUserDetailsByPasswordUsername(string userName, string password)
        {
            return UserDetailBL.GetUserDetailsByPasswordUsername(userName, password);
        }

        public static List<ModuleEntity> GetModules(UserEntity userEntity)
        {
            return ModuleBL.GetModules(userEntity);
        }

        public static UserEntity GetUserDetailsBy(Expression<Func<UserEntity, bool>> selector)
        {
            return UserDetailBL.GetUserDetailsBy(selector);
        }

        public static int AddUpdateUserDetails(UserEntity userDetails)
        {
            return UserDetailBL.AddUpdateUserDetails(userDetails);
        }

        public static bool ForgotPassword(UserEntity userDetails)
        {
            return UserDetailBL.ForgotPassword(userDetails);
        }

        //public static List<SubModuleEntity> GetSubModulesBy(Expression<Func<SubModuleEntity, bool>> selector)
        //{
        //    return SubModuleBL.GetSubModulesBy(selector);
        //}

        public static List<UserEntity> GetAllUserDetails()
        {
            return UserDetailBL.GetAllUserDetails();
        }

        public static async Task<List<UserRoleEntity>> GetUserRolesAsync()
        {
            return UserRoleBL.GetUserRoles();
        }

        public static List<UserRoleEntity> GetUserRoles()
        {
            return UserRoleBL.GetUserRoles();
        }

        public static async Task<List<UserRoleEntity>> GetModulesByUserRoleIdAsync(int userRoleId)
        {
            return UserRoleBL.GetModulesByUserRoleId(userRoleId);
        }

        public static List<UserRoleEntity> GetModulesByUserRoleId(int userRoleId)
        {
            return UserRoleBL.GetModulesByUserRoleId(userRoleId);
        }

        //public static List<UserCategoryEntity> GetUserCategories()
        //{
        //    return UserCategoryBL.GetUserCategories();
        //}

        public static async Task<List<ModuleEntity>> GetAllModulesAsync()
        {
            return ModuleBL.GetAllModules();
        }

        public static List<ModuleEntity> GetAllModules()
        {
            return ModuleBL.GetAllModules();
        }

        //public static List<SubModuleEntity> GetAllSubModules()
        //{
        //    return SubModuleBL.GetAllSubModules();
        //}

        public static bool DeleteUserDetails(int id)
        {
            return UserDetailBL.DeleteUserDetails(id);
        }

        //public static List<LogEntity> GetLogDetailsBy(Expression<Func<LogEntity, bool>> selector = null)
        //{
        //    return LogDetailBL.GetLogDetailsBy(selector);
        //}

        //public static bool DeleteLog(int id)
        //{
        //    return LogDetailBL.DeleteLog(id);
        //}
    }
}
