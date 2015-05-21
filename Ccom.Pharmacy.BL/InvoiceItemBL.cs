using System;
using System.Collections.Generic;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Data.DataAdapters.ManageInvoiceItem;

namespace Ccom.Pharmacy.BL
{
    public class InvoiceItemBL
    {
        public static List<InvoiceItemEntity> GetAllInvoiceItem()
        {
            try
            {
                InvoiceItemCommand invoiceItemCommand = new InvoiceItemCommand();
                return invoiceItemCommand.GetAllInvoiceItem();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static List<InvoiceItemEntity> GetInvoiceItemByInvoiceId(int invoiceId)
        {
            try
            {
                //InvoiceItemCommand invoiceItemCommand = new InvoiceItemCommand();
                //return invoiceItemCommand.GetInvoiceItemByInvoiceId(invoiceId);
                return InvoiceItemFacade.GetInvoiceItemByInvoiceId(invoiceId);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }
        public static InvoiceItemEntity GetInvoiceItemById(int id)
        {
            try
            {
                InvoiceItemCommand invoiceItemCommand = new InvoiceItemCommand();
                return invoiceItemCommand.GetInvoiceItemById(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity)
        {
            try
            {
                InvoiceItemCommand invoiceItemCommand = new InvoiceItemCommand();
                return invoiceItemCommand.AddUpdateInvoiceItem(invoiceItemEntity);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return 0;
            }
        }

        public static bool DeleteInvoiceItem(int id)
        {
            try
            {
                InvoiceItemCommand invoiceItemCommand = new InvoiceItemCommand();
                return invoiceItemCommand.DeleteInvoiceItem(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            }
        }
    }
}
