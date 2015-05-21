using System.Windows;
using Ccom.Pharmacy.ViewModels;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for SupplierView.xaml
    /// </summary>
    public partial class SupplierView
    {
        public SupplierView()
        {
            InitializeComponent();
            SupplierViewModel supplierViewModel = DataContext as SupplierViewModel;
            if (supplierViewModel == null) return;
            supplierViewModel.ToSetManageViewRequestEvent += _supplierViewModel_ToSetManageViewRequestEvent;
            supplierViewModel.ToChangeVisualStateRequestEvent += _supplierViewModel_ToChangeVisualStateRequestEvent;
        }

        private void _supplierViewModel_ToSetManageViewRequestEvent(SupplierManageView supplierManageView)
        {
            GrdManageView.Children.Clear();
            GrdManageView.Children.Add(supplierManageView);
        }

        private void _supplierViewModel_ToChangeVisualStateRequestEvent(string visualStateName)
        {
            VisualStateManager.GoToState(this, visualStateName, true);
        }
    }
}
