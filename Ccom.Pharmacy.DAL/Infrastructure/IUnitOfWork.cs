namespace Ccom.Pharmacy.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void ProxyCreation(bool isEnable = true);
    }
}
