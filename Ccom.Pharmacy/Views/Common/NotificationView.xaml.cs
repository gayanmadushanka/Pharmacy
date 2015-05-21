using Ccom.Pharmacy.Core;
using Ccom.Pharmacy.Core.Enums;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.ViewModels.Common;

namespace Ccom.Pharmacy.Views.Common
{
    /// <summary>
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    public partial class NotificationView
    {
        public NotificationView(IOSNotificationType notificationType, string message)
        {
            InitializeComponent();
            NavigationManager.FlowView.Push(this);
            NotificationViewModel notificationViewModel = DataContext as NotificationViewModel;
            if (notificationViewModel != null)
            {
                notificationViewModel.InitializeNotification(notificationType);
                notificationViewModel.NotificationLoadingMsg = message;
            }
        }

        public NotificationView(IOSNotification notification, string message)
        {
            InitializeComponent();
            NavigationManager.FlowView.Push(this);
            NotificationViewModel notificationViewModel = DataContext as NotificationViewModel;
            if (notificationViewModel != null)
            {
                notificationViewModel.Notification = notification;
                notificationViewModel.NotificationLoadingMsg = message;
            }
        }
    }
}
