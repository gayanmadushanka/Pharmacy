using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.Item
{
    public class ItemRepository : RepositoryBase<ItemEntity>, IItemRepository
    {
        public ItemRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
