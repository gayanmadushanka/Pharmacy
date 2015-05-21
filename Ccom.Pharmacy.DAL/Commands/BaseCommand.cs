using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Commands
{
    public class BaseCommand
    {
        public readonly IDatabaseFactory DatabaseFactory;
        public readonly IUnitOfWork UnitOfWork;

        public BaseCommand()
        {
            DatabaseFactory = new DatabaseFactory();
            UnitOfWork = new UnitOfWork(DatabaseFactory);
        }
    }
}
