using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ccom.Pharmacy.DAL.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private DataBaseContext _dataContext;
        private readonly IDbSet<T> _dbset;

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected DataBaseContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }

        public virtual void Insert(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;

            //DbEntityEntry<T> dbEntityEntry = _dataContext.Entry(entity);
            //dbEntityEntry.Property(a=>a.Email)
            // _dbset.Attach(entity);
            //var dbEntry=_dataContext.Entry(entity);
            // dbEntry.Property(x=>x.) = true;
            // //.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects) _dbset.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public virtual T GetById(string id)
        {
            return _dbset.Find(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }

        //public virtual IEnumerable<T> GetAll()
        //{
        //    return _dbset.ToList();
        //}

        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }
    }
}
