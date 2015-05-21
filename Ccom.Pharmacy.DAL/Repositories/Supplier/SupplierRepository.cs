using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.Supplier
{
    public class SupplierRepository : RepositoryBase<SupplierEntity>, ISupplierRepository
    {
        public SupplierRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
