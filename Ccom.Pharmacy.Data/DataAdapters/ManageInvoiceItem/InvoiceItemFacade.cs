using System.Collections.Generic;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Data.DataAdapters.SQLServer;
using Ccom.Pharmacy.Data.SystemObjects;

namespace Ccom.Pharmacy.Data.DataAdapters.ManageInvoiceItem
{
    public class InvoiceItemFacade
    {
        private static ISQLServerAdapter GetDataAdapter()
        {
            return new SQLServerAdapter();
        }

        public static List<InvoiceItemEntity> GetAllInvoiceItem()
        {
            return GetDataAdapter().GetAllInvoiceItem();
        }

        public static List<InvoiceItemEntity> GetInvoiceItemByInvoiceId(int invoiceId)
        {
            return GetDataAdapter().GetInvoiceItemByInvoiceId(invoiceId);
        }

        public static int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity)
        {
            return GetDataAdapter().AddUpdateInvoiceItem(invoiceItemEntity);
        }

        public static bool DeleteInvoiceItem(int id)
        {
            return GetDataAdapter().DeleteInvoiceItem(id);
        }
    }
}
