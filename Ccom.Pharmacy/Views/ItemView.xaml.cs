using System.Windows;
using Ccom.Pharmacy.ViewModels;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView
    {
        public ItemView()
        {
            InitializeComponent();
            ItemViewModel itemViewModel = DataContext as ItemViewModel;
            if (itemViewModel == null) return;
            itemViewModel.ToSetManageViewRequestEvent += _itemViewModel_ToSetManageViewRequestEvent;
            itemViewModel.ToChangeVisualStateRequestEvent += _itemViewModel_ToChangeVisualStateRequestEvent;
        }

        private void _itemViewModel_ToSetManageViewRequestEvent(ItemManageView itemManageView)
        {
            GrdManageView.Children.Clear();
            GrdManageView.Children.Add(itemManageView);
        }

        private void _itemViewModel_ToChangeVisualStateRequestEvent(string visualStateName)
        {
            VisualStateManager.GoToState(this, visualStateName, true);
        }
    }
}
