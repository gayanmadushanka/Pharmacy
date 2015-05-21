using System;
using System.Collections.Generic;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.ItemCategory;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class ItemCategoryCommand : BaseCommand
    {
        protected readonly IItemCategoryRepository ItemCategoryRepository;

        public ItemCategoryCommand()
        {
            ItemCategoryRepository = new ItemCategoryRepository(DatabaseFactory);
        }

        public List<ItemCategoryEntity> GetAllItemCategory()
        {
            try
            {
                return ItemCategoryRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public ItemCategoryEntity GetItemCategoryById(int id)
        {
            try
            {
                return ItemCategoryRepository.GetById(id);
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public int AddUpdateItemCategory(ItemCategoryEntity itemCategoryEntity)
        {
            try
            {
                if (itemCategoryEntity.Id == 0)
                {
                    ItemCategoryRepository.Insert(itemCategoryEntity);
                }
                else
                {
                    ItemCategoryRepository.Update(itemCategoryEntity);
                }
                UnitOfWork.Commit();
                return itemCategoryEntity.Id;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return -1;
            }
        }

        public bool DeleteItemCategory(int id)
        {
            try
            {
                ItemCategoryRepository.Delete(x => x.Id == id);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return false;
            }
        }
    }
}

