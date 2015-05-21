using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ccom.Common.DomainObjects;
using Ccom.Common.Email;
using Ccom.Common.Utils;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class UserDetailBL
    {
        public static UserEntity GetUserDetailsByPasswordUsername(string userName, string password)
        {
            try
            {
                UserDetailsCommand userDetailsCommand = new UserDetailsCommand();
                return userDetailsCommand.GetUserDetailsByPasswordUsername(userName, PasswordHelper.Encrypt(password));
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static UserEntity GetUserDetailsBy(Expression<Func<UserEntity, bool>> selector)
        {
            try
            {
                UserDetailsCommand userDetailsCommand = new UserDetailsCommand();
                return userDetailsCommand.GetUserDetailsBy(selector);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static List<UserEntity> GetAllUserDetails()
        {
            try
            {
                UserDetailsCommand userDetailsCommand = new UserDetailsCommand();
                List<UserEntity> userEntities = userDetailsCommand.GetAllUserDetails();
                foreach (var userEntity in userEntities)
                {
                    userEntity.Password = PasswordHelper.Decrypt(userEntity.Password);
                }
                return userEntities;
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static bool ForgotPassword(UserEntity userDetails)
        {
            try
            {
                if (userDetails != null)
                {
                    ForgotPassword forgotPassword = new ForgotPassword
                    {
                        Name = userDetails.FirstName,
                        Password = PasswordHelper.Decrypt(userDetails.Password),
                        Url = "http://localhost:3641"
                    };

                    EmailEntity emailEntity = new EmailEntity
                    {
                        Subject = "Your Kiosk Account Password",
                        TemplateName = "\\ForgotPasswordMailTemplate\\ForgotPasswordMailTemplate.cshtml",
                        ToEmailAddress = userDetails.Email
                    };

                    EmailUtill.SendAcyncEmail(forgotPassword, emailEntity);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            }
        }

        public static int AddUpdateUserDetails(UserEntity userDetails)
        {
            try
            {
                UserDetailsCommand userDetailsCommand = new UserDetailsCommand();
                userDetails.Password = PasswordHelper.Encrypt(userDetails.Password);
                return userDetailsCommand.AddUpdateUserDetails(userDetails);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return 0;
            }
        }

        public static bool DeleteUserDetails(int id)
        {
            try
            {
                UserDetailsCommand userDetailsCommand = new UserDetailsCommand();
                return userDetailsCommand.DeleteUserDetails(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            }
        }
    }
}
