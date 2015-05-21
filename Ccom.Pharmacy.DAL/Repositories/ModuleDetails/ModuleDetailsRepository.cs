using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.ModuleDetails
{
    public class ModuleDetailsRepository : RepositoryBase<ModuleEntity>, IModuleDetailsRepository
    {
        public ModuleDetailsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
