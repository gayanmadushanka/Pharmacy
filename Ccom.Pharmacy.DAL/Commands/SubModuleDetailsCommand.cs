using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.SubModuleDetails;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class SubModuleDetailsCommand : BaseCommand
    {
        protected readonly ISubModuleDetailsRepository SubModuleDetailsRepository;

        public SubModuleDetailsCommand()
        {
            SubModuleDetailsRepository = new SubModuleDetailsRepository(DatabaseFactory);
        }

        public List<SubModuleEntity> GetSubModulesBy(Expression<Func<SubModuleEntity, bool>> selector)
        {
            try
            {
                return SubModuleDetailsRepository.FindBy(selector).ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public List<SubModuleEntity> GetAllSubModules()
        {
            try
            {
                return SubModuleDetailsRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}

