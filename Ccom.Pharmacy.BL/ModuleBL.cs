using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class ModuleBL
    {
        public static List<ModuleEntity> GetModules(UserEntity userEntity)
        {
            List<ModuleEntity> moduleList = new List<ModuleEntity>();
            try
            {
                //UserEntity userEntity = UserDetailBL.GetUserDetailsByPasswordUsername(userName, passWord);
                //moduleList = userEntity.UserRole.ModuleEntities.ToList();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
            }
            return moduleList;
        }

        public static List<ModuleEntity> GetAllModules()
        {
            try
            {
                ModuleDetailsCommand moduleDetailsCommand = new ModuleDetailsCommand();
                return moduleDetailsCommand.GetAllModules();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
            }
            return null;
        }
    }
}
