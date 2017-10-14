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
        /// <returns></returns>
        PraticienDetailDto GetDetailPraticien(int idPraticien);

    }
}
