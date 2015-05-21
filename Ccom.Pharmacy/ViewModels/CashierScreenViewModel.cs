using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Views;

namespace Ccom.Pharmacy.ViewModels
{
    public class CashierScreenViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        private string _itemCategoryName = string.Empty;
        private ItemEntity _itemEntity;

        #region Properties
        private InvoiceEntity _invoice = new InvoiceEntity { Date = DateTime.Now, InvoiceItemEntities = new ObservableCollection<InvoiceItemEntity>() };
        public InvoiceEntity Invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                NotifyPropertyChanged(ConstantManager.Invoice);
            }
        }

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

        private double _subAmount = 0.00;
        public double SubAmount
        {
            get { return _subAmount; }
            set
            {
                _subAmount = value;
                NotifyPropertyChanged("SubAmount");
            }
        }

        private double _totalAmount = 0.00;
        public double TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                NotifyPropertyChanged("TotalAmount");
            }
        }

        private double _balance = 0.00;
        public double Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                NotifyPropertyChanged("Balance");
            }
        }
        #endregion

        public ICommand ItemSelectionCommand { get; set; }
        public ICommand PrintInvoiceCommand { get; set; }
        public ICommand CancelInvoiceCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public ICommand DiscountSelectionCommand { get; set; }
        public ICommand CashSelectionCommand { get; set; }

        public CashierScreenViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            GetAllItem();
            GetAllItemCategory();
            GetInvoiceNo();

            ItemSelectionCommand = new DelegateCommand<object, object>(ExecuteItemSelectionCommand);
            PrintInvoiceCommand = new DelegateCommand<object, object>(ExecutePrintInvoiceCommand);
            CancelInvoiceCommand = new DelegateCommand<object, object>(ExecuteCancelInvoiceCommand);
            DeleteItemCommand = new DelegateCommand<object, object>(ExecuteDeleteItemCommand);
            FilterCommand = new DelegateCommand<object, object>(ExecuteFilterCommand);
            DiscountSelectionCommand = new DelegateCommand<object, object>(ExecuteDiscountSelectionCommand);
            CashSelectionCommand = new DelegateCommand<object, object>(ExecuteCashSelectionCommand);
        }

        private async void GetAllItem()
        {
            try
            {
                ItemList = new ObservableCollection<ItemEntity>(await PharmacyAPI.GetAllItemAsync());
                ItemCollection = new ListCollectionView(ItemList);
                //_serviceAgent.GetAllItem((s, e) =>
                //{
                //    if (e.Error == null)
                //    {
                //        ItemList = e.Result;
                //        ItemCollection = new ListCollectionView(ItemList);
                //    }
                //});
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private async void GetInvoiceNo()
        {
            try
            {
                //Invoice.InvoiceNo = await PharmacyAPI.GetInvoiceNo();
                Invoice.InvoiceNo = PharmacyAPI.GetInvoiceNo();
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private async void GetAllItemCategory()
        {
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

        private void ExecuteItemSelectionCommand(object obj)
        {
            try
            {
                if (obj != null)
                {
                    _itemEntity = obj as ItemEntity;
                    if (_itemEntity != null)
                    {
                        QuantityView quantityView = new QuantityView(_itemEntity.Quantity);
                        quantityView.FeedBackResponseEvent += quantityView_FeedBackResponseEvent;
                        quantityView.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private void quantityView_FeedBackResponseEvent(int response)
        {
            if (_itemEntity != null)
            {
                foreach (var item in ItemList.Where(item => item.Equals(_itemEntity)))
                {
                    item.Quantity -= response;
                    break;
                }
                Invoice.InvoiceItemEntities.Add(new InvoiceItemEntity { ItemId = _itemEntity.Id, Item = _itemEntity, Quantity = response, TotalAmount = response * _itemEntity.UnitPrice });
                SubAmount = Invoice.SubAmount += _itemEntity.UnitPrice * response;
                TotalAmount = Invoice.TotalAmount += _itemEntity.UnitPrice * response;
            }
        }

        private void ExecutePrintInvoiceCommand(object obj)
        {
            AddUpdateInvoice();
            PrintInvoice(Invoice);

            Invoice = null;
            Invoice = new InvoiceEntity { Date = DateTime.Now, InvoiceItemEntities = new ObservableCollection<InvoiceItemEntity>() };
            GetAllItem();
            GetInvoiceNo();
            SubAmount = 0.00;
            TotalAmount = 0.00;
            Balance = 0.00;
        }

        private void ExecuteCancelInvoiceCommand(object obj)
        {
            try
            {
                Invoice = new InvoiceEntity { InvoiceItemEntities = new ObservableCollection<InvoiceItemEntity>() };
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private void ExecuteDeleteItemCommand(object obj)
        {
            try
            {
                if (obj != null)
                {
                    InvoiceItemEntity invoiceItemEntity = obj as InvoiceItemEntity;
                    Invoice.InvoiceItemEntities.Remove(invoiceItemEntity);
                    if (invoiceItemEntity != null)
                    {
                        foreach (var item in ItemList.Where(item => item.Equals(invoiceItemEntity.Item)))
                        {
                            item.Quantity += invoiceItemEntity.Quantity;
                            break;
                        }
                        SubAmount = Invoice.SubAmount -= invoiceItemEntity.TotalAmount;
                        TotalAmount = Invoice.TotalAmount -= invoiceItemEntity.TotalAmount;
                    }
                }
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private void ExecuteDiscountSelectionCommand(object obj)
        {
            try
            {
                string discount = obj as string;
                Invoice.Discount = Convert.ToDouble(discount);
                TotalAmount = Invoice.TotalAmount = (Invoice.SubAmount * (100 - Invoice.Discount) / 100);
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private void ExecuteCashSelectionCommand(object obj)
        {
            try
            {
                string cash = obj as string;
                Balance = Invoice.Balance = Invoice.TotalAmount - Convert.ToDouble(cash);
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private void PrintInvoice(InvoiceEntity invoice)
        {
            try
            {
                PharmacyAPI.PrintInvoice(invoice);
                //_serviceAgent.PrintInvoice(invoice, (s, e) =>
                //{
                //    if (e.Error == null)
                //    {

                //    }
                //});
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private async void AddUpdateInvoice()
        {
            try
            {
                Invoice.Date = DateTime.Now;
                //foreach (var invoiceItem in Invoice.InvoiceItemEntities)
                //{
                //    await PharmacyAPI.AddUpdateItemAsync(invoiceItem.Item);
                //}
                await PharmacyAPI.AddUpdateInvoiceAsync(Invoice);
                //_serviceAgent.AddUpdateInvoice(Invoice, (s, e) =>
                //{
                //    if (e.Error == null)
                //    {

                //    }
                //});
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
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
