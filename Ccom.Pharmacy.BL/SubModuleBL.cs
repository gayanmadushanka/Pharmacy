using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class SubModuleBL
    {
        public static List<SubModuleEntity> GetSubModulesBy(Expression<Func<SubModuleEntity, bool>> selector)
        {
            try
            {
                SubModuleDetailsCommand subModuleDetailsCommand = new SubModuleDetailsCommand();
                return subModuleDetailsCommand.GetSubModulesBy(selector);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static List<SubModuleEntity> GetAllSubModules()
        {
            try
            {
                SubModuleDetailsCommand subModuleDetailsCommand = new SubModuleDetailsCommand();
                return subModuleDetailsCommand.GetAllSubModules();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }
    }
}
