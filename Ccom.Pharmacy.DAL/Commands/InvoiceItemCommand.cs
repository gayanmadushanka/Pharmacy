using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.InvoiceItem;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class InvoiceItemCommand : BaseCommand
    {
        protected readonly IInvoiceItemRepository InvoiceItemRepository;

        public InvoiceItemCommand()
        {
            InvoiceItemRepository = new InvoiceItemRepository(DatabaseFactory);
        }

        public List<InvoiceItemEntity> GetAllInvoiceItem()
        {
            try
            {
                return InvoiceItemRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public List<InvoiceItemEntity> GetInvoiceItemByInvoiceId(int invoiceId)
        {
            try
            {
                return InvoiceItemRepository.FindBy(x=>x.InvoiceId==invoiceId).ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public InvoiceItemEntity GetInvoiceItemById(int id)
        {
            try
            {
                return InvoiceItemRepository.GetById(id);
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity)
        {
            try
            {
                if (invoiceItemEntity.Id == 0)
                {
                    InvoiceItemRepository.Insert(invoiceItemEntity);
                }
                else
                {
                    InvoiceItemRepository.Update(invoiceItemEntity);
                }
                UnitOfWork.Commit();
                return invoiceItemEntity.Id;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return -1;
            }
        }

        public bool DeleteInvoiceItem(int id)
        {
            try
            {
                InvoiceItemRepository.Delete(x => x.Id == id);
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

