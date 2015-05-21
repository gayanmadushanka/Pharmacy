using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.UserRole;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class UserRoleCommand : BaseCommand
    {
        protected readonly IUserRoleRepository UserRoleRepository;

        public UserRoleCommand()
        {
            UserRoleRepository = new UserRoleRepository(DatabaseFactory);
        }

        public List<UserRoleEntity> GetModulesByUserRoleId(int userRoleId)
        {
            try
            {
                return UserRoleRepository.GetAll().Where(x => x.Id == userRoleId).Include(x => x.ModuleEntities).ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public List<UserRoleEntity> GetUserRoles()
        {
            try
            {
                return UserRoleRepository.GetAll().Include(x => x.ModuleEntities).ToList();
                //return UserRoleRepository.GetAll().Include(x => x.ModuleEntities).Include(x => x.SubModuleEntities).ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}
