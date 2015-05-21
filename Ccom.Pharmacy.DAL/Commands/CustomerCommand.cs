using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.Customer;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class CustomerCommand : BaseCommand
    {
        protected readonly ICustomerRepository CustomerRepository;

        public CustomerCommand()
        {
            CustomerRepository = new CustomerRepository(DatabaseFactory);
        }

        public List<CustomerEntity> GetAllCustomer()
        {
            try
            {
                return CustomerRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public CustomerEntity GetCustomerById(int id)
        {
            try
            {
                return CustomerRepository.GetById(id);
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public int AddUpdateCustomer(CustomerEntity customerEntity)
        {
            try
            {
                if (customerEntity.Id == 0)
                {
                    CustomerRepository.Insert(customerEntity);
                }
                else
                {
                    CustomerRepository.Update(customerEntity);
                }
                UnitOfWork.Commit();
                return customerEntity.Id;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return -1;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                CustomerRepository.Delete(x => x.Id == id);
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
