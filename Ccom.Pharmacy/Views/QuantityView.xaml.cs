using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Ccom.Pharmacy.Delegates;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for QuantityView.xaml
    /// </summary>
    public partial class QuantityView
    {
        public event FeedBack<int> FeedBackResponseEvent;
        private int _quantity;

        public QuantityView(int quantity)
        {
            InitializeComponent();
            _quantity = quantity;
            TbAvailableQuantity.Text = quantity.ToString(CultureInfo.InvariantCulture);
            TbQuantity.Focus();
        }

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            if (FeedBackResponseEvent != null) FeedBackResponseEvent(Convert.ToInt32(TbQuantity.Text));
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TbQuantity_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TbAvailableQuantity.Text = (_quantity - Convert.ToInt32(TbQuantity.Text)).ToString(CultureInfo.InvariantCulture);
        }
    }
}