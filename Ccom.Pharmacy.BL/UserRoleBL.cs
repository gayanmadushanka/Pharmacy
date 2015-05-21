using System;
using System.Collections.Generic;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class UserRoleBL
    {
        public static List<UserRoleEntity> GetModulesByUserRoleId(int userRoleId)
        {
            try
            {
                UserRoleCommand userDetailsCommand = new UserRoleCommand();
                return userDetailsCommand.GetModulesByUserRoleId(userRoleId);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static List<UserRoleEntity> GetUserRoles()
        {
            try
            {
                UserRoleCommand userDetailsCommand = new UserRoleCommand();
                return userDetailsCommand.GetUserRoles();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }
    }
}
