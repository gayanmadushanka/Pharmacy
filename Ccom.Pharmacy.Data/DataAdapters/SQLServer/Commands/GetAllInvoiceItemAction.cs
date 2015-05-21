using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    class GetAllInvoiceItemAction : USDBActionBase<List<InvoiceItemEntity>>
    {
        protected override List<InvoiceItemEntity> Body(DbConnection connection)
        {
            const string storedProcedureName = "SpGetAllInvoiceItem";
            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                DbDataReader reader = cmd.ExecuteReader();
                List<InvoiceItemEntity> invoiceItemEntities = new List<InvoiceItemEntity>();

                while (reader.Read())
                {
                    InvoiceItemEntity invoiceItemEntity = new InvoiceItemEntity();
                    invoiceItemEntity.Id = Convert.ToInt32(reader["Id"]);
                    //invoiceItemEntity.Name = Convert.ToString(reader["Name"]);
                    //invoiceItemEntity.Quantity = Convert.ToInt32(reader["Quantity"]);
                    //invoiceItemEntity.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    //invoiceItemEntity.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                    //invoiceItemEntity.ExpireDate = Convert.ToDateTime(reader["ExpireDate"]);
                    //invoiceItemEntity.InvoiceItemCategory = new InvoiceItemCategoryEntity
                    //{
                    //    Id = Convert.ToInt32(reader["InvoiceItemCategoryId"]),
                    //    Name = Convert.ToString(reader["InvoiceItemCategoryName"])
                    //};
                    //invoiceItemEntity.Supplier = new SupplierEntity
                    //{
                    //    Id = Convert.ToInt32(reader["SupplierId"]),
                    //    FirstName = Convert.ToString(reader["SupplierName"])
                    //};
                    //invoiceItemEntity.InvoiceItemCategoryId = invoiceItemEntity.InvoiceItemCategory.Id;
                    //invoiceItemEntity.SupplierId = invoiceItemEntity.Supplier.Id;
                    invoiceItemEntities.Add(invoiceItemEntity);
                }
                return invoiceItemEntities;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}
