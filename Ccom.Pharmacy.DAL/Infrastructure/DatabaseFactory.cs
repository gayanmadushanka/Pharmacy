namespace Ccom.Pharmacy.DAL.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DataBaseContext _dataContext;

        public DataBaseContext Get()
        {
            return _dataContext ?? (_dataContext = new DataBaseContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
