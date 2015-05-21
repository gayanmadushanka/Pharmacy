using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.UserCategory;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class UserCategoryCommand : BaseCommand
    {
        protected readonly IUserCategoryRepository UserCategoryRepository;

        public UserCategoryCommand()
        {
            UserCategoryRepository = new UserCategoryRepository(DatabaseFactory);
        }

        public List<UserCategoryEntity> GetUserCategories()
        {
            try
            {
                return UserCategoryRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}
