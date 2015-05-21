using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Views;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ccom.Pharmacy.ViewModels
{
    public class ItemViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToChangeVisualStateRequest ToChangeVisualStateRequestEvent;
        public event ToSetManageViewRequest<ItemManageView> ToSetManageViewRequestEvent;

        private string _itemCategoryName = string.Empty;
        private ItemManageView _itemManageView;
        private string _excelFileName;

        #region Item Properties
        private ObservableCollection<ItemEntity> _itemList = new ObservableCollection<ItemEntity>();
        public ObservableCollection<ItemEntity> ItemList
        {
            get { return _itemList; }
            set
            {
                _itemList = value;
                NotifyPropertyChanged(ConstantManager.ItemList);
            }
        }

        private string _searchByItemName = string.Empty;
        public string SearchByItemName
        {
            get { return _searchByItemName; }
            set
            {
                _searchByItemName = value;
                NotifyPropertyChanged(ConstantManager.SearchByItemName);
            }
        }

        private ListCollectionView _itemCollection;
        public ListCollectionView ItemCollection
        {
            get { return _itemCollection; }
            set
            {
                _itemCollection = value;
                NotifyPropertyChanged(ConstantManager.ItemCollection);
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

        public ICommand AddItemCommand { get; set; }
        public ICommand EditItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand ImportExcelSheetCommand { get; set; }
        public ICommand FilterCommand { get; set; }

        public ItemViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            AddItemCommand = new DelegateCommand<object, object>(ExecuteAddItemCommand);
            EditItemCommand = new DelegateCommand<object, object>(ExecuteEditItemCommand);
            DeleteItemCommand = new DelegateCommand<object, object>(ExecuteDeleteItemCommand);
            ImportExcelSheetCommand = new DelegateCommand<object, object>(ExecuteImportExcelSheetCommand);
            FilterCommand = new DelegateCommand<object, object>(ExecuteFilterCommand);
            GetAllItem();
            GetAllItemCategory();
        }

        private async void GetAllItem(bool? isSuccess = null, bool isFirst = true)
        {
            //ItemList = new ObservableCollection<ItemEntity>(await PharmacyAPI.GetAllItemAsync());
            ItemList = new ObservableCollection<ItemEntity>(await PharmacyAPI.GetAllItemAsync());
            ItemCollection = new ListCollectionView(ItemList);
            if (!isFirst)
            {
                if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            }
            //_serviceAgent.GetAllItem((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        ItemList = e.Result;
            //    }
            //    if (!isFirst)
            //    {
            //        if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            //    }
            //});
        }

        private async void GetAllItemCategory()
        {
            ItemCategoryList = new ObservableCollection<ItemCategoryEntity>();
            ItemCategoryList.Add(new ItemCategoryEntity { Name = "All" });
            List<ItemCategoryEntity> itemCategoryEntities = await PharmacyAPI.GetAllItemCategoryAsync();
            foreach (var itemCategoryEntity in itemCategoryEntities)
            {
                ItemCategoryList.Add(itemCategoryEntity);
            }

            //_serviceAgent.GetAllItemCategory((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        ItemCategoryList.Add(new ItemCategoryEntity { Name = "All" });
            //        foreach (var itemCategoryEntity in e.Result)
            //        {
            //            ItemCategoryList.Add(itemCategoryEntity);
            //        }
            //    }
            //});
        }

        private void ExecuteAddItemCommand(object obj)
        {
            _itemManageView = new ItemManageView();
            var itemManageViewModel = _itemManageView.DataContext as ItemManageViewModel;
            if (itemManageViewModel != null)
            {
                itemManageViewModel.Item = new ItemEntity();
                itemManageViewModel.GetAllSupplier();
                itemManageViewModel.GetAllItemCategory();
                itemManageViewModel.ToManageEntityResponseEvent += itemManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_itemManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void ExecuteEditItemCommand(object obj)
        {
            var selectedItem = obj as ItemEntity;
            _itemManageView = new ItemManageView();
            var itemManageViewModel = _itemManageView.DataContext as ItemManageViewModel;
            if (itemManageViewModel != null)
            {
                itemManageViewModel.Item = selectedItem.Clone();
                itemManageViewModel.IsEdit = true;
                itemManageViewModel.GetAllSupplier();
                itemManageViewModel.GetAllItemCategory();
                itemManageViewModel.ToManageEntityResponseEvent += itemManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_itemManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void itemManageViewModel_ToManageEntityResponseEvent(bool? isSuccess)
        {
            GetAllItem(isSuccess, false);
        }

        private void ExecuteDeleteItemCommand(object obj)
        {
            if (_itemManageView == null)
            {
                var selectedItem = obj as ItemEntity;
                if (selectedItem != null) DeleteItem(selectedItem.Id);
            }
            else
            {
                var itemManageViewModel = _itemManageView.DataContext as ItemManageViewModel;
                _itemManageView = new ItemManageView();

                var item = new ItemEntity();
                if (itemManageViewModel != null) itemManageViewModel.Item = item.Clone();

                var selectedItem = obj as ItemEntity;
                if (selectedItem != null) DeleteItem(selectedItem.Id);
            }
        }

        private void ExecuteImportExcelSheetCommand(object obj)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".xls",
                Filter = "Text documents (.xls)|*.xls"
            };

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                _excelFileName = dlg.FileName;
                PopUpManager.LoadProgressBar("");
                RunBackgroundWorker();
            }
        }

        private void RunBackgroundWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadExcelFile(_excelFileName);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GetAllItemCategory();
            GetAllItem();
            NavigationManager.GoBack();
        }

        private void ReadExcelFile(string fileName)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                Excel.Range range = xlWorkSheet.UsedRange;

                GetItemValue(range);

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private async void GetItemValue(Excel.Range range)
        {
            try
            {
                List<ItemCategoryEntity> itemCategoryEntities = await PharmacyAPI.GetAllItemCategoryAsync();
                List<SupplierEntity> supplierEntities = await PharmacyAPI.GetAllSupplierAsync();
                for (int rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                {
                    ItemEntity itemEntity = new ItemEntity();
                    for (int cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        if (range.Cells[rCnt, cCnt] as Excel.Range != null)
                        {
                            switch (cCnt)
                            {
                                case 1:
                                    itemEntity.Name = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                    break;
                                case 2:
                                    itemEntity.WholeSalePrice = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                    break;
                                case 3:
                                    itemEntity.UnitPrice = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                    break;
                                case 4:
                                    itemEntity.Quantity = Convert.ToInt32((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                                    break;
                                case 5:
                                    object value2 = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;

                                    if (value2 != null)
                                    {
                                        if (value2 is double)
                                        {
                                            itemEntity.ExpireDate = DateTime.FromOADate((double)value2);
                                        }
                                        else
                                        {
                                            DateTime expireDate;
                                            DateTime.TryParse((string)value2, out expireDate);
                                            itemEntity.ExpireDate = expireDate;
                                        }
                                    }
                                    //itemEntity.ExpireDate = 
                                    break;
                                case 6:
                                    string supplierName = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                    int supplierId;
                                    if (!IsSupplierAvailable(supplierName, supplierEntities, out supplierId))
                                    {
                                        itemEntity.SupplierId = PharmacyAPI.AddUpdateSupplierAsync(new SupplierEntity { FirstName = supplierName }).Result;
                                        supplierEntities.Add(new SupplierEntity { Id = itemEntity.SupplierId, FirstName = supplierName });
                                    }
                                    else
                                    {
                                        itemEntity.SupplierId = supplierId;
                                    }
                                    break;
                                case 7:
                                    string itemCategoryName = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                    int itemCategoryId;
                                    if (!IsItemCategoryAvailable(itemCategoryName, itemCategoryEntities, out itemCategoryId))
                                    {
                                        itemEntity.ItemCategoryId = PharmacyAPI.AddUpdateItemCategoryAsync(new ItemCategoryEntity { Name = itemCategoryName }).Result;
                                        itemCategoryEntities.Add(new ItemCategoryEntity { Id = itemEntity.ItemCategoryId, Name = itemCategoryName });
                                    }
                                    else
                                    {
                                        itemEntity.ItemCategoryId = itemCategoryId;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    itemEntity.Discount = itemEntity.UnitPrice == 0.00 ? 0 : ((itemEntity.UnitPrice - itemEntity.WholeSalePrice) / itemEntity.UnitPrice) * 100;
                    itemEntity.TotalAmount = itemEntity.UnitPrice * itemEntity.Quantity;
                    SavaItem(itemEntity);
                }
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private bool IsSupplierAvailable(string supplieName, List<SupplierEntity> supplieEntities, out int supplieId)
        {
            foreach (var supplieEntity in supplieEntities)
            {
                if (supplieEntity.FirstName == supplieName)
                {
                    supplieId = supplieEntity.Id;
                    return true;
                }
            }
            supplieId = 0;
            return false;
        }

        private bool IsItemCategoryAvailable(string itemCategoryName, List<ItemCategoryEntity> itemCategoryEntities, out int itemCategoryId)
        {
            foreach (var itemCategoryEntity in itemCategoryEntities)
            {
                if (itemCategoryEntity.Name == itemCategoryName)
                {
                    itemCategoryId = itemCategoryEntity.Id;
                    return true;
                }
            }
            itemCategoryId = 0;
            return false;
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
            finally
            {
                GC.Collect();
            }
        }

        private async void SavaItem(ItemEntity itemEntity)
        {
            await PharmacyAPI.AddUpdateItemAsync(itemEntity);
            //_serviceAgent.AddUpdateItem(itemEntity, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {

            //    }
            //});
        }

        private async void DeleteItem(int id)
        {
            await PharmacyAPI.DeleteItemAsync(id);
            GetAllItem();
            //_serviceAgent.DeleteItem(id, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        GetAllItem();
            //    }
            //});
        }

        private void ExecuteFilterCommand(object obj)
        {
            try
            {
                if (ItemCollection == null) return;
                ItemCollection.Filter = FilterItem;
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private bool FilterItem(object obj)
        {
            try
            {
                if (SelectedItemCategory != null)
                    _itemCategoryName = SelectedItemCategory.Name;

                ItemEntity itemEntity = obj as ItemEntity;
                if (_itemCategoryName == ConstantManager.All)
                {
                    return itemEntity != null
                           && (itemEntity.Name.Trim().ToLower().StartsWith(SearchByItemName.Trim().ToLower()));
                }
                return itemEntity != null
                    && (itemEntity.Name.Trim().ToLower().StartsWith(SearchByItemName.Trim().ToLower())
                    && (itemEntity.ItemCategory.Name == _itemCategoryName));
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
            return false;
        }
    }
}
