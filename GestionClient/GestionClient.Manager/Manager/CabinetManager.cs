using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Data;
using GestionClient.Manager.Interface;
using System.Linq.Expressions;
using LinqKit;

namespace GestionClient.Manager
{
    public class CabinetManager :
        CrudManager<GestionClientEntities, Cabinet>,
        ICabinetManager
    {
        public override Cabinet GetById(int Id)
        {

            return Context.Cabinet.FirstOrDefault(c => c.ID == Id);

        }


        public IEnumerable<Cabinet> Search(Expression<Func<Cabinet, bool>> predicate)
        {

            return Context.Cabinet.AsEnumerable().Where(predicate.Compile());
        }


        //public override void CreateItem(Cabinet item)
        //{
        //    using (var testContext = new GestionClientEntities())
        //    {
        //        testContext.Cabinet.Add(item);
        //        testContext.SaveChangesAsync().Wait();
        //        var cabinets = this.GetAll();
        //    }
        //}
    }
}
