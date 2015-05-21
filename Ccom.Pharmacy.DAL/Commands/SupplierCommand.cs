using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.Supplier;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class SupplierCommand : BaseCommand
    {
        protected readonly ISupplierRepository SupplierRepository;

        public SupplierCommand()
        {
            SupplierRepository = new SupplierRepository(DatabaseFactory);
        }

        public List<SupplierEntity> GetAllSupplier()
        {
            try
            {
                return SupplierRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public SupplierEntity GetSupplierById(int id)
        {
            try
            {
                return SupplierRepository.GetById(id);
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public int AddUpdateSupplier(SupplierEntity supplierEntity)
        {
            try
            {
                if (supplierEntity.Id == 0)
                {
                    SupplierRepository.Insert(supplierEntity);
                }
                else
                {
                    SupplierRepository.Update(supplierEntity);
                }
                UnitOfWork.Commit();
                return supplierEntity.Id;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return -1;
            }
        }

        public bool DeleteSupplier(int id)
        {
            try
            {
                SupplierRepository.Delete(x => x.Id == id);
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
