using System.Windows;
using Ccom.Pharmacy.ViewModels;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView
    {
        public CustomerView()
        {
            InitializeComponent();
            CustomerViewModel customerViewModel = DataContext as CustomerViewModel;
            if (customerViewModel == null) return;
            customerViewModel.ToSetManageViewRequestEvent += _customerViewModel_ToSetManageViewRequestEvent;
            customerViewModel.ToChangeVisualStateRequestEvent += _customerViewModel_ToChangeVisualStateRequestEvent;
        }

        private void _customerViewModel_ToSetManageViewRequestEvent(CustomerManageView customerManageView)
        {
            GrdManageView.Children.Clear();
            GrdManageView.Children.Add(customerManageView);
        }

        private void _customerViewModel_ToChangeVisualStateRequestEvent(string visualStateName)
        {
            VisualStateManager.GoToState(this, visualStateName, true);
        }
    }
}
