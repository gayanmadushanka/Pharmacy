using System.Windows;
using Ccom.Pharmacy.ViewModels;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for ItemCategoryView.xaml
    /// </summary>
    public partial class ItemCategoryView
    {
        public ItemCategoryView()
        {
            InitializeComponent();
            ItemCategoryViewModel itemCategoryViewModel = DataContext as ItemCategoryViewModel;
            if (itemCategoryViewModel == null) return;
            itemCategoryViewModel.ToSetManageViewRequestEvent += _itemCategoryViewModel_ToSetManageViewRequestEvent;
            itemCategoryViewModel.ToChangeVisualStateRequestEvent += _itemCategoryViewModel_ToChangeVisualStateRequestEvent;
        }

        private void _itemCategoryViewModel_ToSetManageViewRequestEvent(ItemCategoryManageView itemCategoryManageView)
        {
            GrdManageView.Children.Clear();
            GrdManageView.Children.Add(itemCategoryManageView);
        }

        private void _itemCategoryViewModel_ToChangeVisualStateRequestEvent(string visualStateName)
        {
            VisualStateManager.GoToState(this, visualStateName, true);
        }
    }
}
