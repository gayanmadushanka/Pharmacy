using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    public class AddUpdateInvoiceItemAction : USDBActionBase<int>
    {
        private readonly InvoiceItemEntity _invoiceItemEntity;
        public AddUpdateInvoiceItemAction(InvoiceItemEntity invoiceItemEntity)
        {
            _invoiceItemEntity = invoiceItemEntity;
        }

        protected override int Body(DbConnection connection)
        {
            int outputId = 0;
            const string storedProcedureName = "SpAddUpdateInvoiceItem";

            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Id", DbType.Int32, _invoiceItemEntity.Id));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Quantity", DbType.Int32, _invoiceItemEntity.Quantity));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@ItemId", DbType.Int32, _invoiceItemEntity.ItemId));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@InvoiceId", DbType.Int32, _invoiceItemEntity.InvoiceId));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@TotalAmount", DbType.Double, _invoiceItemEntity.TotalAmount));

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
