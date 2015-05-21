using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    class GetAllInvoiceAction : USDBActionBase<List<InvoiceEntity>>
    {
        protected override List<InvoiceEntity> Body(DbConnection connection)
        {
            const string storedProcedureName = "SpGetAllInvoice";
            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                DbDataReader reader = cmd.ExecuteReader();
                List<InvoiceEntity> invoiceEntities = new List<InvoiceEntity>();

                while (reader.Read())
                {
                    InvoiceEntity invoiceEntity = new InvoiceEntity();
                    invoiceEntity.Id = Convert.ToInt32(reader["Id"]);
                    //invoiceEntity.Name = Convert.ToString(reader["Name"]);
                    //invoiceEntity.Quantity = Convert.ToInt32(reader["Quantity"]);
                    //invoiceEntity.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    //invoiceEntity.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                    //invoiceEntity.ExpireDate = Convert.ToDateTime(reader["ExpireDate"]);
                    //invoiceEntity.InvoiceCategory = new InvoiceCategoryEntity
                    //{
                    //    Id = Convert.ToInt32(reader["InvoiceCategoryId"]),
                    //    Name = Convert.ToString(reader["InvoiceCategoryName"])
                    //};
                    //invoiceEntity.Supplier = new SupplierEntity
                    //{
                    //    Id = Convert.ToInt32(reader["SupplierId"]),
                    //    FirstName = Convert.ToString(reader["SupplierName"])
                    //};
                    //invoiceEntity.InvoiceCategoryId = invoiceEntity.InvoiceCategory.Id;
                    //invoiceEntity.SupplierId = invoiceEntity.Supplier.Id;
                    invoiceEntities.Add(invoiceEntity);
                }
                return invoiceEntities;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}
