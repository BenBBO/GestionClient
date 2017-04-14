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
        /// Récupérations de tous les cabinets répondant au critères passés en paramètre
        /// </summary>
        /// <param name="searchCriteria">Critère de recherche</param>
        /// <returns>Liste des CabinetDto</returns>
        IEnumerable<CabinetDto> GetCabinets(CabinetSearchDto searchCriteria);

        /// <summary>
        /// Méthode d'ajout d'un nouveau cabinet
        /// </summary>
        /// <param name="cabinet">Données du cabinet</param>
        void AddCabinet(CabinetAddDto cabinet);

    }
}
