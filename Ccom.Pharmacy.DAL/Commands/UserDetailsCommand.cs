using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.UserDetails;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class UserDetailsCommand : BaseCommand
    {
        protected readonly IUserDetailsRepository UserDetailsRepository;

        public UserDetailsCommand()
        {
            UserDetailsRepository = new UserDetailsRepository(DatabaseFactory);
        }

        public UserEntity GetUserDetailsByPasswordUsername(string userName, string passWord)
        {
            try
            {
                //UnitOfWork.ProxyCreation();
                return UserDetailsRepository.GetAll().Where(x => x.UserName.Equals(userName) && x.Password.Equals(passWord)).First();
                //.Include(x => x.UserRole).Include(x => x.UserCategory).First();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public UserEntity GetUserDetailsBy(Expression<Func<UserEntity, bool>> selector)
        {
            try
            {
                return UserDetailsRepository.FindBy(selector).First();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public List<UserEntity> GetAllUserDetails()
        {
            try
            {
                return UserDetailsRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public int AddUpdateUserDetails(UserEntity userDetails)
        {
            try
            {
                if (userDetails.Id == 0)
                {
                    UserDetailsRepository.Insert(userDetails);
                    UnitOfWork.Commit();
                }
                else
                {
                    UserDetailsRepository.Update(userDetails);
                    UnitOfWork.Commit();
                }
                return userDetails.Id;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return -1;
            }
        }

        public bool DeleteUserDetails(int id)
        {
            try
            {
                UserDetailsRepository.Delete(x => x.Id == id);
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
