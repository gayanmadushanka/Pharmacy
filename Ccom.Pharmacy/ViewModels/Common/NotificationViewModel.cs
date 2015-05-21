using System.Windows;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.Core;
using Ccom.Pharmacy.Core.Enums;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Properties;
using LoadingControl.Control;

namespace Ccom.Pharmacy.ViewModels.Common
{
    public class NotificationViewModel : INPCBase
    {
        #region Properties
        private IOSNotification _notification;
        public IOSNotification Notification
        {
            get { return _notification; }
            set
            {
                _notification = value;
                NotifyPropertyChanged(ConstantManager.Notification);
            }
        }

        private string _notificationLoadingMsg = Resources.GoToFrontDesk;
        public string NotificationLoadingMsg
        {
            get { return _notificationLoadingMsg; }
            set
            {
                _notificationLoadingMsg = value;
                NotifyPropertyChanged(ConstantManager.NotificationLoadingMsg);
            }
        }
        #endregion

        public ICommand OkBtnClickedCommand { get; private set; }
        public ICommand CancelBtnClickedCommand { get; private set; }

        public NotificationViewModel()
        {
            OkBtnClickedCommand = new DelegateCommand<object, object>(ExecuteOkBtnClickedCommand);
            CancelBtnClickedCommand = new DelegateCommand<object, object>(ExecuteCancelBtnClickedCommand);
        }

        public void InitializeNotification(IOSNotificationType notificationType)
        {
            LoadingAnimation a = new LoadingAnimation();
            IOSNotification notification = new IOSNotification();
            switch (notificationType)
            {
                case IOSNotificationType.PleaseWait:
                    notification.Title = Resources.GoToFrontDesk;
                    notification.ProgressBarVisibility = Visibility.Visible;
                    notification.CancelBtnVisibility = Visibility.Visible;
                    break;
                case IOSNotificationType.GoToFrontDesk:
                    notification.Title = Resources.GoToFrontDesk;
                    notification.ImagePath = "/Images/placeholder_person.gif";
                    notification.CancelBtnVisibility = Visibility.Visible;
                    break;
            }
            Notification = notification;
        }

        public void ExecuteOkBtnClickedCommand(object parameter)
        {

        }

        public void ExecuteCancelBtnClickedCommand(object parameter)
        {
            NavigationManager.GoBack();
        }
    }
}
