using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Repositories.Item;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class ItemCommand : BaseCommand
    {
        protected readonly IItemRepository ItemRepository;

        public ItemCommand()
        {
            ItemRepository = new ItemRepository(DatabaseFactory);
        }

        public List<ItemEntity> GetAllItem()
        {
            try
            {
                //int i = 2;
                //int k = 0;
                //int j = i / k;

                //UnitOfWork.ProxyCreation(false);
                return ItemRepository.GetAll().ToList();
                //return ItemRepository.GetAll().Include(x=>x.ItemCategory).ToList();
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public ItemEntity GetItemById(int id)
        {
            try
            {
                return ItemRepository.GetById(id);
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return null;
            }
        }

        public int AddUpdateItem(ItemEntity itemEntity)
        {
            try
            {
                if (itemEntity.Id == 0)
                {
                    ItemRepository.Insert(itemEntity);
                }
                else
                {
                    ItemRepository.Update(itemEntity);
                }
                UnitOfWork.Commit();
                return itemEntity.Id;
            }
            catch (Exception ex)
            {
                if (DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
                return -1;
            }
        }

        public bool DeleteItem(int id)
        {
            try
            {
                ItemRepository.Delete(x => x.Id == id);
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

