using System;
using System.Collections.Generic;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class SupplierBL
    {
        public static List<SupplierEntity> GetAllSupplier()
        {
            try
            {
                SupplierCommand supplierCommand = new SupplierCommand();
                return supplierCommand.GetAllSupplier();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }


        public static SupplierEntity GetSupplierById(int id)
        {
            try
            {
                SupplierCommand supplierCommand = new SupplierCommand();
                return supplierCommand.GetSupplierById(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static int AddUpdateSupplier(SupplierEntity supplierEntity)
        {
            try
            {
                SupplierCommand supplierCommand = new SupplierCommand();
                return supplierCommand.AddUpdateSupplier(supplierEntity);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return 0;
            }
        }

        public static bool DeleteSupplier(int id)
        {
            try
            {
                SupplierCommand supplierCommand = new SupplierCommand();
                return supplierCommand.DeleteSupplier(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            }
        }
    }
}
