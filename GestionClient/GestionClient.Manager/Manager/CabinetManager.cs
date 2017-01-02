using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Data;
using GestionClient.Manager.Interface;

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
    }
}
