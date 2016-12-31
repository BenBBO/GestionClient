using GestionClient.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Manager.Manager
{
    class GenericManager<C, T> :
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

        public virtual void UpdateItem(T item)
        {
            _entities.Entry(item).State = EntityState.Modified;
        }
    }
}
