using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    public class AddUpdateItemAction : USDBActionBase<int>
    {
        private readonly ItemEntity _itemEntity;
        public AddUpdateItemAction(ItemEntity itemEntity)
        {
            _itemEntity = itemEntity;
        }

        protected override int Body(DbConnection connection)
        {
            int outputId = 0;
            const string storedProcedureName = "SpAddUpdateItem";

            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Id", DbType.Int32, _itemEntity.Id));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Name", DbType.String, _itemEntity.Name));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Quantity", DbType.Int32, _itemEntity.Quantity));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@ExpireDate", DbType.DateTime, _itemEntity.ExpireDate));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@UnitPrice", DbType.Double, _itemEntity.UnitPrice));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@WholeSalePrice", DbType.Double, _itemEntity.WholeSalePrice));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Discount", DbType.Double, _itemEntity.Discount));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@TotalAmount", DbType.Double, _itemEntity.TotalAmount));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@SupplierId", DbType.Int32, _itemEntity.SupplierId));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@ItemCategoryId", DbType.Int32, _itemEntity.ItemCategoryId));

                DbParameter dbParameter = new SqlParameter();
                dbParameter.DbType = DbType.Int32;
                dbParameter.ParameterName = "@outPutId";
                dbParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(dbParameter);
                cmd.ExecuteNonQuery();
                outputId = Convert.ToInt32(dbParameter.Value);
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
            }
            return outputId;
        }
    }
}
