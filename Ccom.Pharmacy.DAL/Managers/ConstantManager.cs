
namespace Ccom.Pharmacy.DAL.Managers
{
    public static class ConstantManager
    {
        #region Property Lengths
        public const int NamePropertyLength = 200;
        public const int ColorPropertyLength = 7;
        public const int ImagePathPropertyLength = 100;
        public const int ToolTipPropertyLength = 30;
        public const int PathToLoadPropertyLength = 100;
        public const int PasswordPropertyLength = 128;
        public const int ContactNumberPropertyLength = 10;
        public const int AddressPropertyLength = 100;
        public const int EmailPropertyLength = 100;
        public const int DescriptionPropertyLength = 400;
        public const int AccountNumberPropertyLength = 20;
        public const int CodePropertyLength = 10;
        #endregion

        #region Table Names
        public const string InvoiceTableName = "Invoice";
        public const string ModuleTableName = "Module";
        public const string UserCategoryTableName = "UserCategory";
        public const string UserTableName = "User";
        public const string UserRoleTableName = "UserRole";
        public const string UserRoleWithModuleTableName = "UserRoleWithModule";
        public const string SubModuleTableName = "SubModule";
        public const string UserRoleWithSubModuleTableName = "UserRoleWithSubModule";
        public const string InvoiceItemTableName = "InvoiceItem";
        public const string CustomerTableName = "Customer";

        public const string ItemTableName = "Item";
        public const string ItemCategoryTableName = "ItemCategory";
        public const string SupplierTableName = "Supplier";
        #endregion

        #region Column Names
        public const string UserRoleWithModuleLeftColumn = "UserRoleId";
        public const string UserRoleWithModuleRightColumn = "ModuleId";
        public const string UserRoleWithSubModuleLeftColumn = "UserRoleId";
        public const string UserRoleWithSubModuleRightColumn = "SubModuleId";
        #endregion

        #region Index Names
        //public const string IndexNameForUserNamePassword = "IX_UserNamePassword";
        public const string IndexNameForEmail = "IX_Email";
        public const string IndexNameForUserName = "IX_UserName";
        #endregion
    }
}
