using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class LogDetailBL
    {
        public static List<LogEntity> GetLogDetailsBy(Expression<Func<LogEntity, bool>> selector)
        {
            try
            {
                LogDetailsCommand logDetailsCommand = new LogDetailsCommand();
                return logDetailsCommand.GetLogDetailsBy(selector);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static bool DeleteLog(int id)
        {
            try
            {
                LogDetailsCommand logDetailsCommand = new LogDetailsCommand();
                return logDetailsCommand.DeleteLog(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            }
        }
    }
}
