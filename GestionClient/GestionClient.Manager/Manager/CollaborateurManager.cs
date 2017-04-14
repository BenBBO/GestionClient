using GestionClient.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Data;

namespace GestionClient.Manager
{
    public class CollaborateurManager : 
        CrudManager<GestionClientEntities, Collaborateur>, 
        ICollaborateurManager
    {
        public IEnumerable<Collaborateur> GetByCabinet(int idCabinet)
        {
            return Context.Collaborateur.Where(c => c.ID_CABINET == idCabinet);
        }

        public override Collaborateur GetById(int Id)
        {
            return Context.Collaborateur.FirstOrDefault(c => c.ID == Id);
        }
    }
}
