using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Model.Dto.Collaborateur;

namespace GestionClient.Service.Interface
{
    public interface ICollaborateurService
    {

        /// <summary>
        /// Méthode d'ajout d'un nouvel assistant
        /// </summary>
        /// <param name="assistant">Données d'un assistant</param>
        void AddAssistant(AssistantAddDto assistant);

        /// <summary>
        /// Méthode d'ajout d'un nouvel praticien
        /// </summary>
        /// <param name="praticien">Données d'un praticien</param>
        void AddPraticien(PraticienAddDto praticien);

        /// <summary>
        /// Méthode de récupération du détail d'un praticien
        /// </summary>
        /// <param name="idPraticien">Identifiant du praticien</param>
        PraticienDetailDto GetDetailPraticien(int idPraticien);

        /// <summary>
        /// Méthode de récupération du détail d'un assistant
        /// </summary>
        /// <param name="id">Identifiant du collaborateur</param>
        AssistantDetailDto GetDetailAssistant(int id);

        /// <summary>
        /// Méthode de récupération des données d'un assistant à éditer
        /// </summary>
        /// <param name="id">Identifiant du collaborateur</param>
        AssistantAddDto GetEditAssistant(int id);

        /// <summary>
        /// Méthode de récupération des données d'un praticien à éditer
        /// </summary>
        /// <param name="id">Identifiant du praticien</param>
        PraticienAddDto GetEditPraticien(int id);

        /// <summary>
        /// Méthode d'enregistrement des données d'un assistant
        /// </summary>
        /// <param name="assistant"></param>
        void SaveAssistant(AssistantAddDto assistant);

        /// <summary>
        /// Méthode d'enregistrement des données d'un praticien
        /// </summary>
        /// <param name="praticien"></param>
        void SavePraticien(PraticienAddDto praticien);
    }
}
