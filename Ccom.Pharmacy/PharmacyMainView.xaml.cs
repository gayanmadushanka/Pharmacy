using Ccom.Pharmacy.Managers;
using System.Windows;

namespace Ccom.Pharmacy
{
    /// <summary>
    /// Interaction logic for KIOSKMainView.xaml
    /// </summary>
    public partial class PharmacyMainView
    {
        public PharmacyMainViewModel ViewModel;

        public PharmacyMainView()
        {
            InitializeComponent();

            StaticDataManager.Window = this;
            NavigationManager.ContentPanel = GdContent;
            PopUpManager.MaxPopUpPanel = GdPopUpMaxContent;
            PopUpManager.MiniPopUpPanel = GdPopUpMiniContent;
            PopUpManager.GrHeaderContent = GrHeaderContent;

            ViewModel = DataContext as PharmacyMainViewModel;
            NavigationManager.LoadMainView();
            BtnNormalScreen.IsEnabled = false;
        }

        private void BtnFullScreen_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            BtnNormalScreen.IsEnabled = true;
            BtnFullScreen.IsEnabled = false;
        }

        private void BtnNormalScreen_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.SingleBorderWindow;
            BtnNormalScreen.IsEnabled = false;
            BtnFullScreen.IsEnabled = true;
        }
    }
}