using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.LogDetails
{
    public class LogDetailsRepository : RepositoryBase<LogEntity>, ILogDetailsRepository
    {
        public LogDetailsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
