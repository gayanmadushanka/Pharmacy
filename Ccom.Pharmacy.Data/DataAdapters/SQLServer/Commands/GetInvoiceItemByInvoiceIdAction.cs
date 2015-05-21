using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    class GetInvoiceItemByInvoiceIdAction : USDBActionBase<List<InvoiceItemEntity>>
    {
        private readonly int _invoiceId;
        public GetInvoiceItemByInvoiceIdAction(int invoiceId)
        {
            _invoiceId = invoiceId;
        }

        protected override List<InvoiceItemEntity> Body(DbConnection connection)
        {
            const string storedProcedureName = "SpGetInvoiceItemByInvoiceId";
            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@InvoiceId", DbType.Int32, _invoiceId));
                DbDataReader reader = cmd.ExecuteReader();
                List<InvoiceItemEntity> invoiceItemEntities = new List<InvoiceItemEntity>();

                while (reader.Read())
                {
                    InvoiceItemEntity invoiceItemEntity = new InvoiceItemEntity();
                    invoiceItemEntity.Id = Convert.ToInt32(reader["Id"]);
                    invoiceItemEntity.ItemId = Convert.ToInt32(reader["ItemId"]);
                    invoiceItemEntity.Quantity = Convert.ToInt32(reader["Quantity"]);
                    invoiceItemEntity.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                    invoiceItemEntity.Item = new ItemEntity
                    {
                        Name = Convert.ToString(reader["Name"]),
                        UnitPrice = Convert.ToDouble(reader["UnitPrice"]),
                        WholeSalePrice = Convert.ToDouble(reader["WholeSalePrice"]),
                        Discount = Convert.ToDouble(reader["Discount"]),
                        ExpireDate = Convert.ToDateTime(reader["ExpireDate"])
                    };
                    invoiceItemEntity.Item.ItemCategory = new ItemCategoryEntity
                    {
                        Id = Convert.ToInt32(reader["ItemCategoryId"]),
                        Name = Convert.ToString(reader["ItemCategoryName"])
                    };
                    invoiceItemEntity.Item.Supplier = new SupplierEntity
                    {
                        Id = Convert.ToInt32(reader["SupplierId"]),
                        FirstName = Convert.ToString(reader["SupplierName"])
                    };
                    invoiceItemEntity.Item.ItemCategoryId = invoiceItemEntity.Item.ItemCategory.Id;
                    invoiceItemEntity.Item.SupplierId = invoiceItemEntity.Item.Supplier.Id;
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
