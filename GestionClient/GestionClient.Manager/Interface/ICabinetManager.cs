using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Data;
using System.Linq.Expressions;

namespace GestionClient.Manager.Interface
{

    public interface ICabinetManager : ICrudManager<Cabinet>

    {

        IEnumerable<Cabinet> Search(Expression<Func<Cabinet, bool>> predicate);

    }

}
