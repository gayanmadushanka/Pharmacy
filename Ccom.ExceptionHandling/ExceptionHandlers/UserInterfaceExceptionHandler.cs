using System;
using Ccom.ExceptionHandling.ExceptionTypes;
using Ccom.ExceptionHandling.Helpers;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Ccom.ExceptionHandling.ExceptionHandlers
{
    public static class UserInterfaceExceptionHandler
    {
        public static bool HandleExcetion(ref Exception ex)
        {
            bool rethrow = false;
            try
            {
                if (ex is BaseException)
                {
                    // do nothing as Data Access or Business Logic exception has already been logged / handled
                }
                else
                {
                    rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.UserInterfacePolicy);
                }
            }
            catch (Exception exp)
            {
                ex = exp;
            }
            return rethrow;
        }
    }
}
