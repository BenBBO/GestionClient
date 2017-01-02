using GestionClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Manager.Interface
{
    interface ICollaborateurManager : ICrudManager<Collaborateur>
    {
        
        /// <summary>
        /// Récupération de l'ensemble des collaborateurs d'un cabinet
        /// </summary>
        /// <param name="idCabinet">Identifiant du cabinet</param>
        /// <returns>Enumerable des collaborateurs d'un cabinet</returns>
        IEnumerable<Collaborateur> GetByCabinet(int idCabinet);        

    }
}
