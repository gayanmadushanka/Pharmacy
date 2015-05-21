using System;
using System.Data.SqlClient;
using Ccom.ExceptionHandling.ExceptionTypes;
using Ccom.ExceptionHandling.Helpers;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Ccom.ExceptionHandling.ExceptionHandlers
{
    public static class DataAccessExceptionHandler
    {
        public static bool HandleException(ref Exception ex)
        {
            bool rethrow = false;
            if ((ex is SqlException))
            {
                SqlException dbExp = (SqlException)ex;
                if (dbExp.Number >= 50000)
                {
                    rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.DataAccessCustomPolicy);
                    ex = new DataAccessCustomException(ex.Message);
                }
                else
                {
                    rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.DataAccessPolicy);
                    if (rethrow)
                    {
                        throw ex;
                    }
                }
            }
            else if (ex is InvalidOperationException)
            {
                rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.DataAccessPolicy);
                if (rethrow)
                {
                    throw ex;
                }
            }
            else if (ex is Exception)
            {
                rethrow = ExceptionPolicy.HandleException(ex, ConstantManager.DataAccessPolicy);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return rethrow;
        }
    }
}
