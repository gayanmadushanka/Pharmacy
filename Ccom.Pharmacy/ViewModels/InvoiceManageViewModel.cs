using System;
using System.Windows.Input;
using Ccom.Common.Print;
using Ccom.Common.Utils;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.ViewModels
{
    public class InvoiceManageViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToManageEntityResponse ToManageEntityResponseEvent;

        #region Properties
        private InvoiceEntity _invoice = new InvoiceEntity();
        public InvoiceEntity Invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                NotifyPropertyChanged(ConstantManager.Invoice);
            }
        }
        #endregion

        public ICommand PrintInvoiceCommand { get; set; }
        public ICommand SavaInvoiceCommand { get; set; }
        public ICommand CancelInvoiceCommand { get; set; }

        public InvoiceManageViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            PrintInvoiceCommand = new DelegateCommand<object, object>(ExecutePrintInvoiceCommand);
            SavaInvoiceCommand = new DelegateCommand<object, object>(ExecuteSavaInvoiceCommand);
            CancelInvoiceCommand = new DelegateCommand<object, object>(ExecuteCancelInvoiceCommand);
        }

        private void ExecuteSavaInvoiceCommand(object obj)
        {
            AddUpdateInvoice();
        }

        private void ExecuteCancelInvoiceCommand(object obj)
        {
            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(null);
        }

        private void ExecutePrintInvoiceCommand(object obj)
        {
            PrintInvoice();
            AddUpdateInvoice();
        }

        private void PrintInvoice()
        {
            Invoice.Date = DateTime.Now;
            Invoice.InvoiceItemEntities.Add(new InvoiceItemEntity
            {
                Item = new ItemEntity
                {
                    Name = "gdgf",
                    Description = "sds",
                    UnitPrice = 200
                },
                Quantity = 2,
                TotalAmount = 200
            });
            PrintManager printManager = new PrintManager();
            //printManager.PrintFolio(Invoice);
        }

        private void AddUpdateInvoice()
        {
            //_serviceAgent.AddUpdateInvoice(Invoice, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        if (Invoice.Id != 0)
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
    }
}
