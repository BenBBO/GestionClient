using GestionClient.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GestionClient.Manager
{
    public abstract class CrudManager<C, T> :
        ICrudManager<T> where T : class where C : DbContext, new()
    {

        #region Properties

        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        #endregion

        public virtual void CreateItem(T item)
        {
            _entities.Set<T>().Add(item);
        }

        public virtual void DeleteItem(T item)
        {
            _entities.Set<T>().Remove(item);
        }

        public virtual IEnumerable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public virtual IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> toReturn = _entities.Set<T>().Where(predicate);
            return toReturn;
        }

        public virtual void UpdateItem(T item)
        {
            _entities.Entry(item).State = EntityState.Modified;
        }

        public abstract T GetById(int Id);

    }
}
