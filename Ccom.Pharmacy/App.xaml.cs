using System.Windows;
using Ccom.Pharmacy.Helpers;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Ccom.Pharmacy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SingleInstance.Make();
            base.OnStartup(e);

            InitializeExceptionAndLogging();
        }

        private static void InitializeExceptionAndLogging()
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