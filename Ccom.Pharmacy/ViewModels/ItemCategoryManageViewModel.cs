using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.ViewModels
{
    public class ItemCategoryManageViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToManageEntityResponse ToManageEntityResponseEvent;

        #region Properties
        private ItemCategoryEntity _itemCategory = new ItemCategoryEntity();
        public ItemCategoryEntity ItemCategory
        {
            get { return _itemCategory; }
            set
            {
                _itemCategory = value;
                NotifyPropertyChanged(ConstantManager.ItemCategory);
            }
        }
        #endregion

        public ICommand SavaItemCategoryCommand { get; set; }
        public ICommand CancelItemCategoryCommand { get; set; }

        public ItemCategoryManageViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            SavaItemCategoryCommand = new DelegateCommand<object, object>(ExecuteSavaItemCategoryCommand);
            CancelItemCategoryCommand = new DelegateCommand<object, object>(ExecuteCancelItemCategoryCommand);
        }

        private void ExecuteSavaItemCategoryCommand(object obj)
        {
            PharmacyAPI.AddUpdateItemCategoryAsync(ItemCategory);
            if (ItemCategory.Id != 0)
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(false);
            }
            else
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(true);
            }

            //_serviceAgent.AddUpdateItemCategory(ItemCategory, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        if (ItemCategory.Id != 0)
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

        private void ExecuteCancelItemCategoryCommand(object obj)
        {
            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(null);
        }
    }
}
