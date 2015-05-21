using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.LogDetails;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class LogDetailsCommand : BaseCommand
    {
        protected readonly ILogDetailsRepository LogDetailsRepository;

        public LogDetailsCommand()
        {
            LogDetailsRepository = new LogDetailsRepository(DatabaseFactory);
        }

        public List<LogEntity> GetLogDetailsBy(Expression<Func<LogEntity, bool>> selector)
        {
            try
            {
                if (selector != null)
                    return LogDetailsRepository.FindBy(selector).ToList();
                return LogDetailsRepository.GetAll().Include(x => x.CategoryLogs).ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public bool DeleteLog(int id)
        {
            try
            {
                LogDetailsRepository.Delete(a => a.LogID == id);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return false;
            }
        }
    }
}
