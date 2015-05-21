using System.Collections.ObjectModel;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.ViewModels
{
    public class ItemManageViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToManageEntityResponse ToManageEntityResponseEvent;
        public bool IsEdit;

        #region Properties
        private ItemEntity _item = new ItemEntity();
        public ItemEntity Item
        {
            get { return _item; }
            set
            {
                _item = value;
                NotifyPropertyChanged(ConstantManager.Item);
            }
        }

        private ObservableCollection<SupplierEntity> _supplierList = new ObservableCollection<SupplierEntity>();
        public ObservableCollection<SupplierEntity> SupplierList
        {
            get { return _supplierList; }
            set
            {
                _supplierList = value;
                NotifyPropertyChanged(ConstantManager.SupplierList);
            }
        }

        private SupplierEntity _selectedSupplier;
        //= new SupplierEntity();
        public SupplierEntity SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                NotifyPropertyChanged(ConstantManager.SelectedSupplier);
            }
        }

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

        private ItemCategoryEntity _selectedItemCategory;
        //= new ItemCategoryEntity();
        public ItemCategoryEntity SelectedItemCategory
        {
            get { return _selectedItemCategory; }
            set
            {
                _selectedItemCategory = value;
                NotifyPropertyChanged(ConstantManager.SelectedItemCategory);
            }
        }
        #endregion

        public ICommand SavaItemCommand { get; set; }
        public ICommand CancelItemCommand { get; set; }
        public ICommand ItemCategorySelectionCommand { get; set; }
        public ICommand SupplierSelectionCommand { get; set; }

        public ItemManageViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            SavaItemCommand = new DelegateCommand<object, object>(ExecuteSavaItemCommand);
            CancelItemCommand = new DelegateCommand<object, object>(ExecuteCancelItemCommand);
            ItemCategorySelectionCommand = new DelegateCommand<object, object>(ExecuteItemCategorySelectionCommand);
            SupplierSelectionCommand = new DelegateCommand<object, object>(ExecuteSupplierSelectionCommand);
            //GetAllSupplier();
            //GetAllItemCategory();
        }

        public async void GetAllSupplier()
        {
            SupplierList = new ObservableCollection<SupplierEntity>(await PharmacyAPI.GetAllSupplierAsync());
            if (IsEdit)
            {
                SetSelectedSupplier();
            }
            //_serviceAgent.GetAllSupplier((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        SupplierList = e.Result;
            //        if (IsEdit)
            //        {
            //            SetSelectedSupplier();
            //        }
            //    }
            //});
        }

        private void SetSelectedSupplier()
        {
            foreach (var supplier in SupplierList)
            {
                if (supplier.Id == Item.SupplierId)
                {
                    SelectedSupplier = supplier;
                    break;
                }
            }
        }

        public async void GetAllItemCategory()
        {

            ItemCategoryList = new ObservableCollection<ItemCategoryEntity>(await PharmacyAPI.GetAllItemCategoryAsync());
            if (IsEdit)
            {
                SetSelectedItemCategory();
            }
            //_serviceAgent.GetAllItemCategory((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        ItemCategoryList = e.Result;
            //        if (IsEdit)
            //        {
            //            SetSelectedItemCategory();
            //        }
            //    }
            //});
        }

        private void SetSelectedItemCategory()
        {
            foreach (var itemCategory in ItemCategoryList)
            {
                if (itemCategory.Id == Item.ItemCategoryId)
                {
                    SelectedItemCategory = itemCategory;
                    break;
                }
            }
        }
        private async void ExecuteSavaItemCommand(object obj)
        {
            await PharmacyAPI.AddUpdateItemAsync(Item);
            if (Item.Id != 0)
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(false);
            }
            else
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(true);
            }
            //_serviceAgent.AddUpdateItem(Item, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        if (Item.Id != 0)
            //        {
            //            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(false);
            //        }
            //        else
            //        {
            //            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(true);
            //        }
            //    }
            //});
        }

        private void ExecuteCancelItemCommand(object obj)
        {
            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(null);
        }

        private void ExecuteItemCategorySelectionCommand(object obj)
        {
            Item.ItemCategoryId = SelectedItemCategory.Id;
            if (IsEdit)
            {
                Item.ItemCategory = SelectedItemCategory;
            }
        }

        private void ExecuteSupplierSelectionCommand(object obj)
        {
            Item.SupplierId = SelectedSupplier.Id;
            if (IsEdit)
            {
                Item.Supplier = SelectedSupplier;
            }
        }
    }
}
