using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.ItemCategory
{
    public class ItemCategoryRepository : RepositoryBase<ItemCategoryEntity>, IItemCategoryRepository
    {
        public ItemCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
