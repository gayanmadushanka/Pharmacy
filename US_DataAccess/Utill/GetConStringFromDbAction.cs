using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace US_DataAccess.Utill
{
    public class GetConStringFromDbAction : USDBActionBase<string>
    {
        public string _companyCode = string.Empty;
        public GetConStringFromDbAction(string companyCode)
        {
            _companyCode = companyCode;
        }
        protected override string Body(System.Data.Common.DbConnection connection)
        {
            string spName = "ExceWorkStationGetGymConnection";
            string conection = string.Empty;
            try
            {
                DbCommand command = CreateCommand(System.Data.CommandType.StoredProcedure, spName);
                command.Parameters.Add(DataAcessUtils.CreateParam("@GymCode", System.Data.DbType.String, _companyCode));
                conection = (string)command.ExecuteScalar();
                return conection;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
