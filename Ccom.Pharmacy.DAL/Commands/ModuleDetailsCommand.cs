using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.ModuleDetails;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class ModuleDetailsCommand : BaseCommand
    {
        protected readonly IModuleDetailsRepository ModuleDetailsRepository;

        public ModuleDetailsCommand()
        {
            ModuleDetailsRepository = new ModuleDetailsRepository(DatabaseFactory);
        }

        //public List<ModuleEntity> GetModules(string userName, string passWord)
        //{
        //    try
        //    {
        //        return ModuleDetailsRepository.GetAll().Where(x => x..Equals(userName) && x.Password.Equals(passWord)).ToList();
        //    }
        //   catch (Exception ex)
        //   {
        //      if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
        //      return null;
        //   }
        //}

        public List<ModuleEntity> GetAllModules()
        {
            try
            {
                return ModuleDetailsRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}

