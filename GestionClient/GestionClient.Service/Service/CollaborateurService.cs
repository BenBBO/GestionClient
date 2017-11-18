using GestionClient.Manager.Interface;
using GestionClient.Service.Interface;
using GestionClient.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Model.Dto.Collaborateur;
using GestionClient.Model.Enum;
using GestionClient.Data;

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

        public AssistantAddDto GetEditAssistant(int id)
        {
            var collaborateur = GetCollaborateur(id, RoleEnum.Assistant);
            AssistantAddDto toReturn = null;

            if (collaborateur != null)
            {
                toReturn = collaborateur.GetEditAssistant();
            }

            return toReturn;
        }

        public PraticienAddDto GetEditPraticien(int id)
        {
            var collaborateur = GetCollaborateur(id, RoleEnum.Praticien);
            PraticienAddDto toReturn = null;

            if (collaborateur != null)
            {
                toReturn = collaborateur.GetEditPraticien();
            }

            return toReturn;
        }

        public AssistantDetailDto GetDetailAssistant(int id)
        {
            var collaborateur = GetCollaborateur(id, RoleEnum.Assistant);
            AssistantDetailDto toReturn = null;

            if (collaborateur != null)
            {
                toReturn = collaborateur.GetDetailAssistant();
            }

            return toReturn;
        }

        public PraticienDetailDto GetDetailPraticien(int idPraticien)
        {

            var collaborateur = _collaborateurManager.GetById(idPraticien);
            PraticienDetailDto toReturn = null;

            if (collaborateur != null)
            {
                RoleEnum role;
                if (Enum.TryParse<RoleEnum>(collaborateur.ROLE, out role) && role == RoleEnum.Praticien)
                {
                    toReturn = collaborateur.GetDetailPraticien();
                }

            }

            return toReturn;
        }

        private Collaborateur GetCollaborateur(int idCollaborateur, RoleEnum? roleConstraint)
        {

            Collaborateur toReturn = _collaborateurManager.GetById(idCollaborateur);

            if (toReturn != null && roleConstraint.HasValue)
            {
                RoleEnum role;
                if (Enum.TryParse<RoleEnum>(toReturn.ROLE, out role) && role != roleConstraint.Value)
                {
                    throw new Exception($"Le type du collaborateur {idCollaborateur} ne correspond pas au type demandé {roleConstraint.Value.ToString()}");
                }
            }

            return toReturn;
        }

        public void SaveAssistant(AssistantAddDto assistant)
        {

            if (assistant == null)
            { throw new ArgumentNullException("assistant"); }


            var toEdit = _collaborateurManager.GetById(assistant.Id);

            if (toEdit != null)
            {

                toEdit.EditAssistant(assistant);
                _collaborateurManager.UpdateItem(toEdit);

            }
            else
            {
                throw new Exception($"Aucun assisant correspondant à l'identifiant {assistant.Id}");
            }
        }

        public void SavePraticien(PraticienAddDto praticien)
        {
            if (praticien == null)
            { throw new ArgumentNullException("praticien"); }


            var toEdit = _collaborateurManager.GetById(praticien.Id);

            if (toEdit != null)
            {

                toEdit.EditPraticien(praticien);
                _collaborateurManager.UpdateItem(toEdit);

            }
            else
            {
                throw new Exception($"Aucun praticien correspondant à l'identifiant {praticien.Id}");
            }
        }

        #endregion

    }
}
