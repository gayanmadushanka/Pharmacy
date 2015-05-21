using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.UserCategory
{
    public class UserCategoryRepository : RepositoryBase<UserCategoryEntity>, IUserCategoryRepository
    {
        public UserCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
