using System;
using System.Collections.Generic;
using Ccom.Common.Print;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Data.DataAdapters.ManageInvoice;

namespace Ccom.Pharmacy.BL
{
    public class InvoiceBL
    {
        public static List<InvoiceEntity> GetAllInvoice()
        {
            try
            {
                InvoiceCommand invoiceCommand = new InvoiceCommand();
                return invoiceCommand.GetAllInvoice();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static InvoiceEntity GetInvoiceById(int id)
        {
            try
            {
                InvoiceCommand invoiceCommand = new InvoiceCommand();
                return invoiceCommand.GetInvoiceById(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static int AddUpdateInvoice(InvoiceEntity invoiceEntity)
        {
            try
            {
                //InvoiceCommand invoiceCommand = new InvoiceCommand();
                //return invoiceCommand.AddUpdateInvoice(invoiceEntity);

                return InvoiceFacade.AddUpdateInvoice(invoiceEntity);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return 0;
            }
        }

        public static bool DeleteInvoice(int id)
        {
            try
            {
                InvoiceCommand invoiceCommand = new InvoiceCommand();
                return invoiceCommand.DeleteInvoice(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            }
        }

        public static string GetInvoiceNo()
        {
            try
            {
                return InvoiceFacade.GetInvoiceNo();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static bool PrintInvoice(InvoiceEntity invoice)
        {
            PrintManager printManager = new PrintManager();
            printManager.Print(invoice);
            return true;
        }

        public static List<InvoiceEntity> GetInvoiceDetailsByDateRange(ReportingEntity reportingEntity)
        {
            try
            {
                return InvoiceFacade.GetInvoiceDetailsByDateRange(reportingEntity);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }
    }
}
