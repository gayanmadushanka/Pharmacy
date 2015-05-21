using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    public class AddUpdateInvoiceAction : USDBActionBase<int>
    {
        private readonly InvoiceEntity _invoiceEntity;
        public AddUpdateInvoiceAction(InvoiceEntity invoiceEntity)
        {
            _invoiceEntity = invoiceEntity;
        }

        protected override int Body(DbConnection connection)
        {
            int outputId = 0;
            const string storedProcedureName = "SpAddUpdateInvoice";

            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Id", DbType.Int32, _invoiceEntity.Id));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@InvoiceNo", DbType.String, _invoiceEntity.InvoiceNo));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Date", DbType.DateTime, _invoiceEntity.Date));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@TotalAmount", DbType.Double, _invoiceEntity.TotalAmount));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Cash", DbType.Double, _invoiceEntity.Cash));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Balance", DbType.Double, _invoiceEntity.Balance));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@SubAmount", DbType.Double, _invoiceEntity.SubAmount));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Discount", DbType.Double, _invoiceEntity.Discount));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Description", DbType.String, _invoiceEntity.Description));

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
