using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Ccom.Pharmacy.Service
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication 
    {
        protected void Application_Start()
        {
            InitializeExceptionAndLogging();
        }

        private static void InitializeExceptionAndLogging()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);

            DatabaseProviderFactory databaseProviderFactory = new DatabaseProviderFactory(config);
            DatabaseFactory.SetDatabaseProviderFactory(databaseProviderFactory);

            //DatabaseFactory.CreateDatabase("SqlLoggingDb");

            LogWriterFactory logWriterFactory = new LogWriterFactory(config);
            Logger.SetLogWriter(logWriterFactory.Create());
            ExceptionPolicy.SetExceptionManager(factory.CreateManager());
        }
    }
}