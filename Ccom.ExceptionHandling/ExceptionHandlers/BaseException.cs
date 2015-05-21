using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Ccom.ExceptionHandling.ExceptionHandlers
{
    public static class BaseException
    {
        public static void InitializeExceptionAndLogging()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);

            DatabaseProviderFactory databaseProviderFactory = new DatabaseProviderFactory(config);
            DatabaseFactory.SetDatabaseProviderFactory(databaseProviderFactory);

            LogWriterFactory logWriterFactory = new LogWriterFactory(config);
            Logger.SetLogWriter(logWriterFactory.Create());
            ExceptionPolicy.SetExceptionManager(factory.CreateManager());
        }
    }
}
