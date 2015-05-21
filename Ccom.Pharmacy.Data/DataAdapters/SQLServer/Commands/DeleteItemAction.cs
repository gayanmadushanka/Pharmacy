using System;
using System.Data;
using System.Data.Common;
using Ccom.ExceptionHandling.ExceptionHandlers;
using US_DataAccess;

namespace Ccom.Pharmacy.Data.DataAdapters.SQLServer.Commands
{
    public class DeleteItemAction : USDBActionBase<bool>
    {
        readonly int _id;

        public DeleteItemAction(int id)
        {
            _id = id;
        }

        protected override bool Body(DbConnection connection)
        {
            const string storedProcedureName = "SpDeleteItem";

            try
            {
                DbCommand cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(DataAcessUtils.CreateParam("@Id", DbType.Int32, _id));
                //DbParameter outputPara = new SqlParameter();
                //outputPara.DbType = DbType.Int32;
                //outputPara.ParameterName = "@OutPutId";
                //outputPara.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(outputPara);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
            }
            return true;
        }
    }
}
