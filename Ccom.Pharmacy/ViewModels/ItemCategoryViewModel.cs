using System.Collections.ObjectModel;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Views;

namespace Ccom.Pharmacy.ViewModels
{
    public class ItemCategoryViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToChangeVisualStateRequest ToChangeVisualStateRequestEvent;
        public event ToSetManageViewRequest<ItemCategoryManageView> ToSetManageViewRequestEvent;

        private ItemCategoryManageView _itemCategoryManageView;
        //private ProgressBar _progressBar;

        #region ItemCategory Properties
        private ObservableCollection<ItemCategoryEntity> _itemCategoryList = new ObservableCollection<ItemCategoryEntity>();
        public ObservableCollection<ItemCategoryEntity> ItemCategoryList
        {
            get { return _itemCategoryList; }
            set
            {
                _itemCategoryList = value;
                NotifyPropertyChanged(ConstantManager.ItemCategoryList);
            }
        }
        #endregion

        public ICommand AddItemCategoryCommand { get; set; }
        public ICommand EditItemCategoryCommand { get; set; }
        public ICommand DeleteItemCategoryCommand { get; set; }

        public ItemCategoryViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            GetAllItemCategory();

            AddItemCategoryCommand = new DelegateCommand<object, object>(ExecuteAddItemCategoryCommand);
            EditItemCategoryCommand = new DelegateCommand<object, object>(ExecuteEditItemCategoryCommand);
            DeleteItemCategoryCommand = new DelegateCommand<object, object>(ExecuteDeleteItemCategoryCommand);
        }

        private async void GetAllItemCategory(bool? isSuccess = null, bool isFirst = true)
        {
            ItemCategoryList = new ObservableCollection<ItemCategoryEntity>(await PharmacyAPI.GetAllItemCategoryAsync());
            if (!isFirst)
            {
                if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            }
            //_serviceAgent.GetAllItemCategory((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        ItemCategoryList = e.Result;
            //    }
            //    if (!isFirst)
            //    {
            //        if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            //    }
            //});
        }

        private void ExecuteAddItemCategoryCommand(object obj)
        {
            _itemCategoryManageView = new ItemCategoryManageView();
            var itemCategoryManageViewModel = _itemCategoryManageView.DataContext as ItemCategoryManageViewModel;
            if (itemCategoryManageViewModel != null)
            {
                itemCategoryManageViewModel.ItemCategory = new ItemCategoryEntity();
                itemCategoryManageViewModel.ToManageEntityResponseEvent += itemCategoryManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_itemCategoryManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void ExecuteEditItemCategoryCommand(object obj)
        {
            var selectedItemCategory = obj as ItemCategoryEntity;
            _itemCategoryManageView = new ItemCategoryManageView();
            var itemCategoryManageViewModel = _itemCategoryManageView.DataContext as ItemCategoryManageViewModel;
            if (itemCategoryManageViewModel != null)
            {
                itemCategoryManageViewModel.ItemCategory = selectedItemCategory.Clone();
                itemCategoryManageViewModel.ToManageEntityResponseEvent += itemCategoryManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_itemCategoryManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void itemCategoryManageViewModel_ToManageEntityResponseEvent(bool? isSuccess)
        {
            GetAllItemCategory(isSuccess, false);
        }

        private void ExecuteDeleteItemCategoryCommand(object obj)
        {
            if (_itemCategoryManageView == null)
            {
                var selectedItemCategory = obj as ItemCategoryEntity;
                if (selectedItemCategory != null) DeleteItemCategory(selectedItemCategory.Id);
            }
            else
            {
                var itemCategoryManageViewModel = _itemCategoryManageView.DataContext as ItemCategoryManageViewModel;
                _itemCategoryManageView = new ItemCategoryManageView();

                var itemCategory = new ItemCategoryEntity();
                if (itemCategoryManageViewModel != null) itemCategoryManageViewModel.ItemCategory = itemCategory.Clone();

                var selectedItemCategory = obj as ItemCategoryEntity;
                if (selectedItemCategory != null) DeleteItemCategory(selectedItemCategory.Id);
            }
        }

        private void DeleteItemCategory(int id)
        {
            PharmacyAPI.DeleteItemCategoryAsync(id);
            GetAllItemCategory();
            //_serviceAgent.DeleteItemCategory(id, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        GetAllItemCategory();
            //    }
            //});
        }
    }
}
