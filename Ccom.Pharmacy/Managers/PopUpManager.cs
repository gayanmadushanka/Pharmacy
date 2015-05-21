using System;
using System.Windows;
using System.Windows.Controls;
using Ccom.Pharmacy.Core.Enums;
using Ccom.Pharmacy.Views.Common;

namespace Ccom.Pharmacy.Managers
{
    internal class PopUpManager
    {
        public static bool IsMaxPopupShow;
        public static bool IsMiniPopupShow;
        public static Grid MaxPopUpPanel;
        public static Grid MiniPopUpPanel;
        public static Grid GrHeaderContent;

        public static void ShowMaxPopUp(Control control)
        {
            MaxPopUpPanel.Children.Clear();
            MaxPopUpPanel.Children.Add(control);
            VisualStateManager.GoToElementState(StaticDataManager.Window, ConstantManager.ShowMaxPopUpState, true);
            IsMaxPopupShow = true;
        }

        public static void HideMaxPopUp()
        {
            VisualStateManager.GoToElementState(StaticDataManager.Window, ConstantManager.HideMaxPopUpState, true);
            IsMaxPopupShow = false;
        }

        public static void ShowMiniPopUp(Control control)
        {
            MiniPopUpPanel.Children.Clear();
            MiniPopUpPanel.Children.Add(control);
            VisualStateManager.GoToElementState(StaticDataManager.Window, ConstantManager.ShowMiniPopUpState, true);
            IsMiniPopupShow = true;
        }

        public static void HideMiniPopUp()
        {
            VisualStateManager.GoToElementState(StaticDataManager.Window, ConstantManager.HideMiniPopUpState, true);
            IsMiniPopupShow = false;
        }

        public static void ShowPharmacyMessageView(string massage, MessageTypes messageType)
        {
            PharmacyMessageView kioskMessageView = new PharmacyMessageView(massage, messageType);
            kioskMessageView.ResultEvent += kioskMessageView_ResultEvent;
            ShowMiniPopUp(kioskMessageView);
        }

        private static void kioskMessageView_ResultEvent(Enum result)
        {
            HideMiniPopUp();
        }

        public static void LoadProgressBar(string title)
        {
            GrHeaderContent.Visibility = Visibility.Collapsed;
            NotificationView operation = new NotificationView(IOSNotificationType.PleaseWait, title);
            NavigationManager.AddView(operation);
        }
    }
}
