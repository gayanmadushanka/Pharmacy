using System;
using System.Collections.Generic;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class UserCategoryBL
    {
        public static List<UserCategoryEntity> GetUserCategories()
        {
            try
            {
                UserCategoryCommand userCategoryCommand = new UserCategoryCommand();
                return userCategoryCommand.GetUserCategories();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }
    }
}
