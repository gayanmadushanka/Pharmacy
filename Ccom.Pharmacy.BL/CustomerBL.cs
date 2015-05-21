using System;
using System.Collections.Generic;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class CustomerBL
    {
        public static List<CustomerEntity> GetAllCustomer()
        {
            try
            {
                CustomerCommand customerCommand = new CustomerCommand();
                return customerCommand.GetAllCustomer();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }


        public static CustomerEntity GetCustomerById(int id)
        {
            try
            {
                CustomerCommand customerCommand = new CustomerCommand();
                return customerCommand.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static int AddUpdateCustomer(CustomerEntity customerEntity)
        {
            try
            {
                CustomerCommand customerCommand = new CustomerCommand();
                return customerCommand.AddUpdateCustomer(customerEntity);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return 0;
            }
        }

        public static bool DeleteCustomer(int id)
        {
            try
            {
                CustomerCommand customerCommand = new CustomerCommand();
                return customerCommand.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            }
        }
    }
}
