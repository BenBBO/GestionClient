using System.Collections.Generic;
using GestionClient.Model.Dto.Cabinet;

namespace GestionClient.Service.Interface
{
    public interface ICabinetService
    {

        /// <summary>
        /// Récupération de l'ensemble des cabinets
        /// </summary>
        /// <returns>Liste de CabinetDto</returns>
        IEnumerable<CabinetDto> GetCabinets();

        /// <summary>
        /// Récupère les données d'un cabinet
        /// </summary>
        /// <param name="idCabinet">Identifiant du cabinet</param>
        CabinetDto GetCabinet(int idCabinet);

        /// <summary>
        /// Récupère les données d'un cabinet à éditer
        /// </summary>
        /// <param name="idCabinet">Identifiant du cabinet</param>
        CabinetEditDto GetCabinetToEdit(int idCabinet);

        /// <summary>
        /// Récupérations de tous les cabinets répondant au critères passés en paramètre
        /// </summary>
        /// <param name="searchCriteria">Critère de recherche</param>
        /// <returns>Liste des CabinetDto</returns>
        IEnumerable<CabinetDto> GetCabinets(CabinetSearchDto searchCriteria);

        /// <summary>
        /// Méthode d'ajout d'un nouveau cabinet
        /// </summary>
        /// <param name="cabinet">Données du cabinet</param>
        int AddCabinet(CabinetAddDto cabinet);

        /// <summary>
        /// Méthode d'édition d'un cabinet
        /// </summary>
        /// <param name="cabinet">Données du cabinet</param>
        void SaveCabinet(CabinetEditDto cabinet);

    }
}
