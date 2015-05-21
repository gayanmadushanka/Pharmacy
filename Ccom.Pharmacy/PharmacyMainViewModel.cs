using System.Windows;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Properties;

namespace Ccom.Pharmacy
{
    public class PharmacyMainViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        #region Properties
        private Visibility _logOutBtnVisibility = Visibility.Collapsed;
        public Visibility LogOutBtnVisibility
        {
            get { return _logOutBtnVisibility; }
            set
            {
                _logOutBtnVisibility = value;
                NotifyPropertyChanged(ConstantManager.LogOutBtnVisibility);
            }
        }
        #endregion

        public ICommand GoToHomeCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public PharmacyMainViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            InitialzeStaticData();
            GoToHomeCommand = new DelegateCommand<object, object>(ExecuteGoToHomeCommand);
            LogOutCommand = new DelegateCommand<object, object>(ExecuteLogOutCommand);
            //InitializeExceptionAndLogging();
        }

        //private void InitializeExceptionAndLogging()
        //{
        //    _serviceAgent.InitializeExceptionAndLogging((s, e) =>
        //    {
        //        if (e.Error == null)
        //        {
        //        }
        //    });
        //}

        private static void ExecuteGoToHomeCommand(object obj)
        {
            NavigationManager.LoadMainView();
        }

        private static void ExecuteLogOutCommand(object obj)
        {
            NavigationManager.LoadMainView();
        }

        private static void InitialzeStaticData()
        {
            StaticDataManager.ReportPath = Settings.Default.ReportPath;
            //StaticDataManager.ImagePath = Settings.Default.ImagePath;
            //StaticDataManager.LogPath = Settings.Default.LogPath;
            //StaticDataManager.UserName = Settings.Default.UserName;
            //StaticDataManager.Password = Settings.Default.Password;
        }
    }
}
