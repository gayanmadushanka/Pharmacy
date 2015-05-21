using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    class GetAllItemAction : USDBActionBase<List<ItemEntity>>
    {
        protected override List<ItemEntity> Body(DbConnection connection)
        {
            const string storedProcedureName = "SpGetAllItem";
            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                DbDataReader reader = cmd.ExecuteReader();
                List<ItemEntity> itemEntities = new List<ItemEntity>();

                while (reader.Read())
                {
                    ItemEntity itemEntity = new ItemEntity();
                    itemEntity.Id = Convert.ToInt32(reader["Id"]);
                    itemEntity.Name = Convert.ToString(reader["Name"]);
                    itemEntity.Quantity = Convert.ToInt32(reader["Quantity"]);
                    itemEntity.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    itemEntity.WholeSalePrice = Convert.ToDouble(reader["WholeSalePrice"]);
                    itemEntity.Discount = Convert.ToDouble(reader["Discount"]);
                    itemEntity.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                    if (reader["ExpireDate"] != DBNull.Value)
                    {
                        itemEntity.ExpireDate = Convert.ToDateTime(reader["ExpireDate"]);
                    }
                    itemEntity.ItemCategory = new ItemCategoryEntity
                    {
                        Id = Convert.ToInt32(reader["ItemCategoryId"]),
                        Name = Convert.ToString(reader["ItemCategoryName"])
                    };
                    itemEntity.Supplier = new SupplierEntity
                    {
                        Id = Convert.ToInt32(reader["SupplierId"]),
                        FirstName = Convert.ToString(reader["SupplierName"])
                    };
                    itemEntity.ItemCategoryId = itemEntity.ItemCategory.Id;
                    itemEntity.SupplierId = itemEntity.Supplier.Id;
                    itemEntities.Add(itemEntity);
                }
                return itemEntities;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}
