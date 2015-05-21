using System.Collections.Generic;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.Data.SystemObjects
{
    interface ISQLServerAdapter
    {
        List<ItemEntity> GetAllItem();
        int AddUpdateItem(ItemEntity itemEntity);
        bool DeleteItem(int id);

        List<InvoiceEntity> GetAllInvoice();
        List<InvoiceItemEntity> GetInvoiceItemByInvoiceId(int invoiceId);
        int AddUpdateInvoice(InvoiceEntity invoiceEntity);
        bool DeleteInvoice(int id);
        string GetInvoiceNo();

        List<InvoiceItemEntity> GetAllInvoiceItem();
        int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity);
        bool DeleteInvoiceItem(int id);

        List<InvoiceEntity> GetInvoiceDetailsByDateRange(ReportingEntity reportingEntity);
    }
}
