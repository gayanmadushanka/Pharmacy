using System;
using System.Collections.Generic;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Commands;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Pharmacy.BL
{
    public class ItemCategoryBL
    {
        public static List<ItemCategoryEntity> GetAllItemCategory()
        {
            try
            {
                ItemCategoryCommand itemCategoryCommand = new ItemCategoryCommand();
                return itemCategoryCommand.GetAllItemCategory();
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static ItemCategoryEntity GetItemCategoryById(int id)
        {
            try
            {
                ItemCategoryCommand itemCategoryCommand = new ItemCategoryCommand();
                return itemCategoryCommand.GetItemCategoryById(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return null;
            }
        }

        public static int AddUpdateItemCategory(ItemCategoryEntity itemCategoryEntity)
        {
            try
            {
                ItemCategoryCommand itemCategoryCommand = new ItemCategoryCommand();
                return itemCategoryCommand.AddUpdateItemCategory(itemCategoryEntity);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return 0;
            } 
        }

        public static bool DeleteItemCategory(int id)
        {
            try
            {
                ItemCategoryCommand itemCategoryCommand = new ItemCategoryCommand();
                return itemCategoryCommand.DeleteItemCategory(id);
            }
            catch (Exception ex)
            {
                if (BusinessLogicExceptionHandler.HandleExcetion(ref ex)) throw ex;
                return false;
            } 
        }
    }
}
