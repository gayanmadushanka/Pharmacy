using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.Invoice;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class InvoiceCommand : BaseCommand
    {
        protected readonly IInvoiceRepository InvoiceRepository;

        public InvoiceCommand()
        {
            InvoiceRepository = new InvoiceRepository(DatabaseFactory);
        }

        public List<InvoiceEntity> GetAllInvoice()
        {
            try
            {
                return InvoiceRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public InvoiceEntity GetInvoiceById(int id)
        {
            try
            {
                return InvoiceRepository.GetById(id);
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public int AddUpdateInvoice(InvoiceEntity invoiceEntity)
        {
            try
            {
                if (invoiceEntity.Id == 0)
                {
                    InvoiceRepository.Insert(invoiceEntity);
                }
                else
                {
                    InvoiceRepository.Update(invoiceEntity);
                }
                UnitOfWork.Commit();
                return invoiceEntity.Id;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return -1;
            }
        }

        public bool DeleteInvoice(int id)
        {
            try
            {
                InvoiceRepository.Delete(x => x.Id == id);
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

