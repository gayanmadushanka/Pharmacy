using System.Collections.Generic;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Data.DataAdapters.SQLServer;
using Ccom.Pharmacy.Data.SystemObjects;

namespace Ccom.Pharmacy.Data.DataAdapters.ManageItem
{
    public class ItemFacade
    {
        private static ISQLServerAdapter GetDataAdapter()
        {
            return new SQLServerAdapter();
        }

        public static List<ItemEntity> GetAllItem()
        {
            return GetDataAdapter().GetAllItem();
        }

        public static int AddUpdateItem(ItemEntity itemEntity)
        {
            return GetDataAdapter().AddUpdateItem(itemEntity);
        }

        public static bool DeleteItem(int id)
        {
            return GetDataAdapter().DeleteItem(id);
        }
    }
}
