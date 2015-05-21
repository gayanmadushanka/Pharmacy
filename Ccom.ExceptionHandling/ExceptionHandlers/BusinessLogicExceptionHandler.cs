using System;
using Ccom.ExceptionHandling.ExceptionTypes;
using Ccom.ExceptionHandling.Helpers;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Ccom.ExceptionHandling.ExceptionHandlers
{
    public static class BusinessLogicExceptionHandler
    {
        public static bool HandleExcetion(ref Exception ex)
        {
            //BaseException.InitializeExceptionAndLogging();
            bool rethrow;
            if ((ex is DataAccessException) || (ex is DataAccessCustomException) || (ex is InvalidOperationException))
            {
                rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.PassThroughPolicy);
                ex = new PassThroughException(ex.Message);
            }
            else if (ex is BusinessLogicCustomException)
            {
                rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.BusinessLogicCustomPolicy);
            }
            else
            {
                rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.BusinessLogicPolicy);
            }
            if (rethrow)
            {
                throw ex;
            }
            return rethrow;
        }
    }
}
