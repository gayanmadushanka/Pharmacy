using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using Ccom.ExceptionHandling.ExceptionHandlers;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    class GetInvoiceNoAction : USDBActionBase<string>
    {
        protected override string Body(DbConnection connection)
        {
            const string storedProcedureName = "SpGetLastInvoiceNo";
            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                DbDataReader reader = cmd.ExecuteReader();

                string invoiceNo = string.Empty;
                while (reader.Read())
                {
                    invoiceNo = "SP-" + (Convert.ToInt32(reader["Id"]) + 1).ToString(CultureInfo.InvariantCulture);
                }
                return invoiceNo;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }
    }
}
