using System.Collections.Generic;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands;
using Ccom.Pharmacy.Data.SystemObjects;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer
{
    public class SQLServerAdapter : ISQLServerAdapter
    {
        public List<ItemEntity> GetAllItem()
        {
            GetAllItemAction action = new GetAllItemAction();
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public int AddUpdateItem(ItemEntity itemEntity)
        {
            AddUpdateItemAction action = new AddUpdateItemAction(itemEntity);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public bool DeleteItem(int id)
        {
            DeleteItemAction action = new DeleteItemAction(id);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public List<InvoiceEntity> GetAllInvoice()
        {
            GetAllInvoiceAction action = new GetAllInvoiceAction();
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public int AddUpdateInvoice(InvoiceEntity invoiceEntity)
        {
            AddUpdateInvoiceAction action = new AddUpdateInvoiceAction(invoiceEntity);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public bool DeleteInvoice(int id)
        {
            DeleteInvoiceAction action = new DeleteInvoiceAction(id);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public string GetInvoiceNo()
        {
            GetInvoiceNoAction action = new GetInvoiceNoAction();
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public List<InvoiceItemEntity> GetAllInvoiceItem()
        {
            GetAllInvoiceItemAction action = new GetAllInvoiceItemAction();
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public List<InvoiceItemEntity> GetInvoiceItemByInvoiceId(int invoiceId)
        {
            GetInvoiceItemByInvoiceIdAction action = new GetInvoiceItemByInvoiceIdAction(invoiceId);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public int AddUpdateInvoiceItem(InvoiceItemEntity invoiceItemEntity)
        {
            AddUpdateInvoiceItemAction action = new AddUpdateInvoiceItemAction(invoiceItemEntity);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public bool DeleteInvoiceItem(int id)
        {
            DeleteInvoiceItemAction action = new DeleteInvoiceItemAction(id);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }

        public List<InvoiceEntity> GetInvoiceDetailsByDateRange(ReportingEntity reportingEntity)
        {
            GetInvoiceDetailsByDateRangeAction action = new GetInvoiceDetailsByDateRangeAction(reportingEntity);
            return action.Execute(EnumDatabase.Exceline, "gymCode");
        }
    }
}
