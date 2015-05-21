using System.Windows;
using Ccom.Pharmacy.Core.Enums;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.Views.Common
{
    /// <summary>
    /// Interaction logic for PharmacyMessageView.xaml
    /// </summary>
    public partial class PharmacyMessageView
    {
        public event Result ResultEvent;

        public PharmacyMessageView(string message, MessageTypes messageType, bool isYesNo = false)
        {
            InitializeComponent();
            if (isYesNo)
            {
                BtnCancel.Visibility = Visibility.Collapsed;
                BtnNo.Visibility = Visibility.Visible;
                BtnYes.Visibility = Visibility.Visible;
                GdConfirmation.Visibility = Visibility.Visible;
            }

            switch (messageType)
            {
                case MessageTypes.Error:
                    VisualStateManager.GoToState(this, ConstantManager.ErrorVisualState, true);
                    break;
                case MessageTypes.Warning:
                    VisualStateManager.GoToState(this, ConstantManager.WarningVisualState, true);
                    break;
                case MessageTypes.Information:
                    VisualStateManager.GoToState(this, ConstantManager.SuccessVisualState, true);
                    break;
                default:
                    VisualStateManager.GoToState(this, ConstantManager.SuccessVisualState, true);
                    break;
            }

            TxtMessage.Text = message;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            if (ResultEvent != null) ResultEvent(IOSResultType.Cancel);
        }

        private void BtnYes_OnClick(object sender, RoutedEventArgs e)
        {
            if (ResultEvent != null) ResultEvent(IOSResultType.Yes);
        }

        private void BtnNo_OnClick(object sender, RoutedEventArgs e)
        {
            if (ResultEvent != null) ResultEvent(IOSResultType.No);
        }
    }
}
