
namespace Ccom.ExceptionHandling.Helpers
{
    internal static class ConstantManager
    {
        #region Policy Names
        public const string PassThroughPolicy = "PassThroughPolicy";
        public const string BusinessLogicCustomPolicy = "BusinessLogicCustomPolicy";
        public const string BusinessLogicPolicy = "BusinessLogicPolicy";
        public const string DataAccessCustomPolicy = "DataAccessCustomPolicy";
        public const string DataAccessPolicy = "DataAccessPolicy";
        public const string UserInterfacePolicy = "UserInterfacePolicy";
        public const string OwsAdapterPolicy = "OwsAdapterPolicy";
        public const string CommonPolicy = "CommonPolicy";
        public const string CommonCustomPolicy = "CommonCustomPolicy";

        public const string AppManagerServicePolicy = "AppManagerServicePolicy";

        #endregion
    }
}
