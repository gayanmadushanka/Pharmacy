using System.Globalization;
using System.Windows.Controls;
using Ccom.Pharmacy.ViewModels;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for ItemManageView.xaml
    /// </summary>
    public partial class ItemManageView
    {
        private readonly ItemManageViewModel _itemManageViewModel;
        public ItemManageView()
        {
            InitializeComponent();
            _itemManageViewModel = DataContext as ItemManageViewModel;
        }

        private void TbUnitPrice_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_itemManageViewModel != null)
                TbTotalAmount.Text = (_itemManageViewModel.Item.UnitPrice * _itemManageViewModel.Item.Quantity).ToString(CultureInfo.InvariantCulture);
        }

        private void TbQuantity_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_itemManageViewModel != null)
                TbTotalAmount.Text = (_itemManageViewModel.Item.UnitPrice * _itemManageViewModel.Item.Quantity).ToString(CultureInfo.InvariantCulture);
        }
    }
}
