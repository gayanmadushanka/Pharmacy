using System;
using Ccom.ExceptionHandling.ExceptionTypes;
using Ccom.ExceptionHandling.Helpers;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Ccom.ExceptionHandling.ExceptionHandlers
{
    public static class OwsAdapterExceptionHandler
    {
        public static bool HandleException(ref Exception ex)
        {
            bool rethrow = false;
            if ((ex is OwsAdapterException) || (ex is OwsAdapterCustomException) || (ex is PassThroughException))
            {
                rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.PassThroughPolicy);
                ex = new PassThroughException(ex.Message);
            }
            else if (ex is Exception)
            {
                rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.OwsAdapterPolicy);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return rethrow;
        }
    }
}