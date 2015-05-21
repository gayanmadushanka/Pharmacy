using System.Windows;
using Ccom.Pharmacy.ViewModels;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView
    {
        public InvoiceView()
        {
            InitializeComponent();
            InvoiceViewModel invoiceViewModel = DataContext as InvoiceViewModel;
            if (invoiceViewModel == null) return;
            invoiceViewModel.ToSetManageViewRequestEvent += _invoiceViewModel_ToSetManageViewRequestEvent;
            invoiceViewModel.ToChangeVisualStateRequestEvent += _invoiceViewModel_ToChangeVisualStateRequestEvent;
        }

        private void _invoiceViewModel_ToSetManageViewRequestEvent(InvoiceManageView invoiceManageView)
        {
            GrdManageView.Children.Clear();
            GrdManageView.Children.Add(invoiceManageView);
        }

        private void _invoiceViewModel_ToChangeVisualStateRequestEvent(string visualStateName)
        {
            VisualStateManager.GoToState(this, visualStateName, true);
        }
    }
}
