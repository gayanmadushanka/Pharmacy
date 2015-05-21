using System;
using System.Data.Common;
using US.Payment.Core;
using US_DataAccess.Utill;

namespace US_DataAccess
{
    /// <summary>
    /// This class will hide the Db specific functionality and provide Db resources
    /// through common db interfaces as defined under ADO.NET Common Factory Model.
    /// </summary>
    /// <remarks></remarks>
    public class GenericDBFactory
    {
        /// <summary>
        /// This specifies ADO.NET 2.0 framework to use specified provider classes
        /// to provide requesting database resources
        /// </summary>
        protected const string ProviderInvarientName = "System.Data.SqlClient";

        /// <summary>
        /// Returns the appropriate factory as specified in 'ProviderInvarientName'
        /// to get the database resources. To create Db resources as Commands and Parameters
        /// with generic interface, one should use this Factory.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DbProviderFactory Factory
        {
            get
            {
                return DbProviderFactories.GetFactory(ProviderInvarientName);
            }
        }

        /// <summary>
        /// To get a new Db connection call this method. Returned connection is not yet opened.
        /// Please make sure that you open it before use and then close it after.
        /// </summary>
        /// <returns>new database connection</returns>
        /// <remarks></remarks>
        public static DbConnection GetConnection(EnumDatabase dbName, string companyCode)
        {
            string ConnectionString = string.Empty;
            //if (USPRunTimeVariables.GetConnectionSource() == "Config")
            //{

            //    if (dbName == EnumDatabase.USP)
            //    {
            //        #region Removed.Old code used to read connection string from App.config. 2010.11.26
            //        //ConnectionString=System.Configuration.ConfigurationSettings.AppSettings["connection"];                                       
            //        #endregion
            //        // Connection string read from "USPConfigurations.xml"
            //        ConnectionString = USPRunTimeVariables.GetUSPConnectionString();
            //    }


            //    else if (dbName == EnumDatabase.LOGDB)
            //    {
            //        #region Removed.Old code used to read connection string from App.config. 2010.11.26
            //        //ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["LOGDB_CONNECTION"];
            //        #endregion
            //        // Connection string read from "USPConfigurations.xml"
            //        ConnectionString = USPRunTimeVariables.GetLOGConnectionString();
            //    }

            //    else if (dbName == EnumDatabase.CPM)
            //    {
            //        #region Removed.Old code used to read connection string from App.config. 2010.11.26
            //        //ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["LOGDB_CONNECTION"];
            //        #endregion
            //        // Connection string read from "USPConfigurations.xml"
            //        ConnectionString = USPRunTimeVariables.GetPaymentMachineConnectionString();
            //    }

            //    else if (dbName == EnumDatabase.Report)
            //    {
            //        ConnectionString = USPRunTimeVariables.GetReportServerConnectionString();
            //    }
            //    else if (dbName == EnumDatabase.Search)
            //    {
            //        ConnectionString = USPRunTimeVariables.GetSearchDBConnectionString();
            //    }
            //    else if (dbName == EnumDatabase.Workflow)
            //    {
            //        ConnectionString = USPRunTimeVariables.GetWorkflowConnectionString();
            //    }
            //    DbConnection Connection = Factory.CreateConnection();
            //    Connection.ConnectionString = ConnectionString;
            //    return Connection;
            //}
            //else //Specific to Exceline 
            //{
            //    if (dbName == EnumDatabase.USP)
            //    {
            //        if ((AppDomain.CurrentDomain.GetData(companyCode) == null))
            //        {
            //            ConnectionString = ConnectionStringProvider.GetConStringFromDb(companyCode);
            //            AppDomain.CurrentDomain.SetData(companyCode, ConnectionString);
            //        }
            //        else
            //        {
            //            ConnectionString = AppDomain.CurrentDomain.GetData(companyCode).ToString();
            //        }
            //    }
            //    else if (dbName == EnumDatabase.Exceline)
            //    {
            //        if ((AppDomain.CurrentDomain.GetData(companyCode) == null))
            //        {
            //            ConnectionString = ConnectionStringProvider.GetConStringFromDb(companyCode);
            //            AppDomain.CurrentDomain.SetData(companyCode, ConnectionString);
            //        }
            //        else
            //        {
            //            ConnectionString = AppDomain.CurrentDomain.GetData(companyCode).ToString();
            //        }
            //    }
            //    else if (dbName == EnumDatabase.WorkStation)//here it must get from the config file
            //    {
            //        ConnectionString = USPRunTimeVariables.GetWorkStationConnectionString();
            //    }
                ConnectionString ="Data Source=MADUSHANKA-PC;Initial Catalog=PharmacyDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                DbConnection Connection = Factory.CreateConnection();
                Connection.ConnectionString = ConnectionString;
                return Connection;
            //}
        }

        public static DbConnection GetConnection(EnumDatabase dbName)
        {
            string connectionString = "";
            if (dbName == EnumDatabase.USP)
            {
                #region Removed.Old code used to read connection string from App.config. 2010.11.26
                //ConnectionString=System.Configuration.ConfigurationSettings.AppSettings["connection"];                                       
                #endregion
                // Connection string read from "USPConfigurations.xml"
                connectionString = USPRunTimeVariables.GetUSPConnectionString();
            }
            else if (dbName == EnumDatabase.LOGDB)
            {
                #region Removed.Old code used to read connection string from App.config. 2010.11.26
                //ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["LOGDB_CONNECTION"];
                #endregion
                // Connection string read from "USPConfigurations.xml"
                connectionString = USPRunTimeVariables.GetLOGConnectionString();
            }
            else if (dbName == EnumDatabase.CPM)
            {
                #region Removed.Old code used to read connection string from App.config. 2010.11.26
                //ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["LOGDB_CONNECTION"];
                #endregion
                // Connection string read from "USPConfigurations.xml"
                connectionString = USPRunTimeVariables.GetPaymentMachineConnectionString();
            }
            else if (dbName == EnumDatabase.Report)
            {
                connectionString = USPRunTimeVariables.GetReportServerConnectionString();
            }
            else if (dbName == EnumDatabase.Search)
            {
                connectionString = USPRunTimeVariables.GetSearchDBConnectionString();
            }
            else if (dbName == EnumDatabase.Workflow)
            {
                connectionString = USPRunTimeVariables.GetWorkflowConnectionString();
            }
            DbConnection Connection = Factory.CreateConnection();
            Connection.ConnectionString = connectionString;
            return Connection;
        }

        #region GetConnection overload method
        /// <summary>
        /// To get a new Db connection call this method. Returned connection is not yet opened.
        /// Please make sure that you open it before use and then close it after.
        /// </summary>
        /// <returns>new database connection</returns>
        /// <remarks></remarks>
        public static DbConnection GetConnection(string connectionString)
        {
            DbConnection Connection = Factory.CreateConnection();
            Connection.ConnectionString = connectionString;
            return Connection;
        }
        #endregion
    }
}
