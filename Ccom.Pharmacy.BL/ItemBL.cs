using System;
using System.Collections.Generic;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Data.DataAdapters.ManageItem;

namespace Ccom.Pharmacy.BL
{
    public class ItemBL
    {
        public static List<ItemEntity> GetAllItem()
        {
            try
            {
                //ItemCommand itemCommand = new ItemCommand();
                //List<ItemEntity> itemEntities = itemCommand.GetAllItem();
                return ItemFacade.GetAllItem();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static ItemEntity GetItemById(int id)
        {
            try
            {
                ItemCommand itemCommand = new ItemCommand();
                return itemCommand.GetItemById(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static int AddUpdateItem(ItemEntity itemEntity)
        {
            try
            {
                //ItemCommand itemCommand = new ItemCommand();
                //return itemCommand.AddUpdateItem(itemEntity);
                return ItemFacade.AddUpdateItem(itemEntity);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return 0;
            } 
        }

        public static bool DeleteItem(int id)
        {
            try
            {
                ItemCommand itemCommand = new ItemCommand();
                return itemCommand.DeleteItem(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            } 
        }
    }
}
