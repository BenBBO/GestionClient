using GestionClient.Manager.Interface;
using GestionClient.Service.Interface;
using GestionClient.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Model.Dto.Collaborateur;

namespace GestionClient.Service
{
    public class CollaborateurService : ICollaborateurService
    {
        #region Private members

        private readonly ICollaborateurManager _collaborateurManager;

        #endregion

        #region Constructor

        public CollaborateurService(ICollaborateurManager collaborateurManager)
        {

            _collaborateurManager = collaborateurManager;

        }

        #endregion

        #region Implémentation ICollaborateur

        public void AddAssistant(AssistantAddDto assistant)
        {

            if (assistant == null)
            { throw new ArgumentNullException("assistant"); }
            
            var toAdd = assistant.GetCollaborateur();
            _collaborateurManager.CreateItem(toAdd);

        }

        public void AddPraticien(PraticienAddDto praticien)
        {
            if (praticien == null)
            { throw new ArgumentNullException("praticien"); }

            var toAdd = praticien.GetCabinet();
            _collaborateurManager.CreateItem(toAdd);
        }

        #endregion

    }
}
