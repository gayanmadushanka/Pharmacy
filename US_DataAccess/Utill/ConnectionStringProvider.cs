using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace US_DataAccess.Utill
{
    public class ConnectionStringProvider
    {
        public static string GetConStringFromDb(string companyCode)
        {
            //gma
            //GetConStringFromDbAction action = new GetConStringFromDbAction(companyCode);
            GetConStringFromDbAction action = new GetConStringFromDbAction("UNI");
            return action.Execute(EnumDatabase.WorkStation);
        }
    }
}
