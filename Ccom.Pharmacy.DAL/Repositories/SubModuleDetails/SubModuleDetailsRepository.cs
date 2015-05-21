using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.SubModuleDetails
{
    public class SubModuleDetailsRepository : RepositoryBase<SubModuleEntity>, ISubModuleDetailsRepository
    {
        public SubModuleDetailsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
