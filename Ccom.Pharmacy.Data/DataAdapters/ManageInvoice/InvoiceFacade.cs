using System;
using System.Collections.Generic;
using System.Transactions;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Data.DataAdapters.SQLServer;
using Ccom.Pharmacy.Data.SystemObjects;

namespace Ccom.Pharmacy.Data.DataAdapters.ManageInvoice
{
    public class InvoiceFacade
    {
        private static ISQLServerAdapter GetDataAdapter()
        {
            return new SQLServerAdapter();
        }

        public static List<InvoiceEntity> GetAllInvoice()
        {
            return GetDataAdapter().GetAllInvoice();
        }

        public static int AddUpdateInvoice(InvoiceEntity invoiceEntity)
        {
            int invoiceId = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    invoiceId = GetDataAdapter().AddUpdateInvoice(invoiceEntity);
                    foreach (var invoiceItem in invoiceEntity.InvoiceItemEntities)
                    {
                        invoiceItem.InvoiceId = invoiceId;
                        GetDataAdapter().AddUpdateInvoiceItem(invoiceItem);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
            }
            return invoiceId;
        }

        public static bool DeleteInvoice(int id)
        {
            return GetDataAdapter().DeleteInvoice(id);
        }

        public static string GetInvoiceNo()
        {
            return GetDataAdapter().GetInvoiceNo();
        }

        public static List<InvoiceEntity> GetInvoiceDetailsByDateRange(ReportingEntity reportingEntity)
        {
            return GetDataAdapter().GetInvoiceDetailsByDateRange(reportingEntity);
        }
    }
}
