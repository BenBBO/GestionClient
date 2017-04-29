using GestionClient.Service.Interface;
using System;
using System.Collections.Generic;
using GestionClient.Model.Dto.Cabinet;
using GestionClient.Manager.Interface;
using GestionClient.Service.Mapping;
using GestionClient.Data;
using GestionClient.Service.Utils;
using System.Linq;
using GestionClient.Model.Enum;
using GestionClient.Tools.Extension;

namespace GestionClient.Service
{
    public class CabinetService : ICabinetService
    {

        private readonly ICabinetManager _cabinetManager;

        #region Constructor

        public CabinetService(ICabinetManager cabinetManager)
        {

            _cabinetManager = cabinetManager;

        }

        #endregion

        public IEnumerable<CabinetDto> GetCabinets()
        {

            var cabinetList = _cabinetManager.GetAll();
            return cabinetList.GetCabinetDto();

        }

        public IEnumerable<CabinetDto> GetCabinets(CabinetSearchDto searchCriteria)
        {
            if (searchCriteria == null)
            {
                return GetCabinets();
            }
            else
            {

                //Création du prédicat de recherche
                var predicate = PredicateBuilder.True<Cabinet>();

                //Recherche sur la raison sociale
                if (!string.IsNullOrWhiteSpace(searchCriteria.RaisonSociale))
                {

                    predicate.And(c => c.RAISON_SOCIALE.Contains(searchCriteria.RaisonSociale,
                        StringComparison.InvariantCultureIgnoreCase));

                }

                //Recherche sur la ville
                if (!string.IsNullOrWhiteSpace(searchCriteria.Ville))
                {

                    predicate.And(c => c.VILLE.Contains(searchCriteria.Ville,
                        StringComparison.InvariantCultureIgnoreCase));

                }

                if (searchCriteria.IdPraticien.HasValue)
                {

                    predicate.And(c => c.Collaborateur != null &&
                    c.Collaborateur.Any(co => co.ROLE == RoleEnum.Praticien.ToString() && co.ID == searchCriteria.IdPraticien));

                }

                return _cabinetManager.GetWhere(predicate).GetCabinetDto();

            }
        }

        public void AddCabinet(CabinetAddDto cabinet)
        {

            if (cabinet == null)
            { throw new ArgumentNullException("Aucune donnée de cabinet à ajouter."); }


            //Todo : Vérification des données

            var toAdd = cabinet.GetCabinet();
            _cabinetManager.CreateItem(toAdd);

        }

        public CabinetDto GetCabinet(int idCabinet)
        {
            return _cabinetManager.GetById(idCabinet).GetCabinetDto();
        }
    }
}
