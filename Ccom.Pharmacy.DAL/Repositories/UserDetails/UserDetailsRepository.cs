using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.UserDetails
{
    public class UserDetailsRepository : RepositoryBase<UserEntity>, IUserDetailsRepository
    {
        public UserDetailsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
