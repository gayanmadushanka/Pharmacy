using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    class GetInvoiceDetailsByDateRangeAction : USDBActionBase<List<InvoiceEntity>>
    {
        private readonly ReportingEntity _reportingEntity;
        public GetInvoiceDetailsByDateRangeAction(ReportingEntity reportingEntity)
        {
            _reportingEntity = reportingEntity;
        }

        protected override List<InvoiceEntity> Body(DbConnection connection)
        {
            const string storedProcedureName = "SpGetInvoiceDetailsByDateRange";
            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@FromDate", DbType.DateTime, _reportingEntity.FromDate));
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@ToDate", DbType.DateTime, _reportingEntity.ToDate));

                DbDataReader reader = cmd.ExecuteReader();
                List<InvoiceEntity> invoiceEntities = new List<InvoiceEntity>();

                while (reader.Read())
                {
                    InvoiceEntity invoiceEntity = new InvoiceEntity();
                    invoiceEntity.Id = Convert.ToInt32(reader["Id"]);
                    invoiceEntity.Date = Convert.ToDateTime(reader["Date"]);
                    invoiceEntity.Description = Convert.ToString(reader["Description"]);
                    invoiceEntity.InvoiceNo = Convert.ToString(reader["InvoiceNo"]);
                    invoiceEntity.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                    invoiceEntity.Cash = Convert.ToDouble(reader["Cash"]);
                    invoiceEntity.Balance = Convert.ToDouble(reader["Balance"]);
                    invoiceEntity.Discount = Convert.ToDouble(reader["Discount"]);
                    invoiceEntity.SubAmount = Convert.ToDouble(reader["SubAmount"]);
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
