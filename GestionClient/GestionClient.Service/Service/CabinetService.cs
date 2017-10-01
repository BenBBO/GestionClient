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
        private readonly ICollaborateurManager _collaborateurManager;

        #region Constructor

        public CabinetService(ICabinetManager cabinetManager, ICollaborateurManager collaborateurManager)
        {

            _cabinetManager = cabinetManager;
            _collaborateurManager = collaborateurManager;

        }

        #endregion

        public IEnumerable<CabinetDto> GetCabinets()
        {

            var toReturn = new List<CabinetDto>();
            var cabinetList = _cabinetManager.GetAll();

            foreach (Cabinet cabinet in cabinetList)
            {

                var collaborateurs = _collaborateurManager.GetByCabinet(cabinet.ID);
                var toAdd = cabinet.GetCabinetDto(collaborateurs);

                if (toAdd != null)
                {
                    toReturn.Add(toAdd);
                }

            }


            return toReturn;

        }

        public IEnumerable<CabinetDto> GetCabinets(CabinetSearchDto searchCriteria)
        {
            if (searchCriteria == null)
            {
                return GetCabinets();
            }
            else
            {

                var toReturn = new List<CabinetDto>();

                //Création du prédicat de recherche
                var predicate = PredicateBuilder.True<Cabinet>();

                //Recherche sur la raison sociale
                if (!string.IsNullOrWhiteSpace(searchCriteria.RaisonSociale))
                {

                    predicate = predicate.And(c => c.RAISON_SOCIALE.Contains(searchCriteria.RaisonSociale,
                        StringComparison.InvariantCultureIgnoreCase));

                }

                //Recherche sur la ville
                if (!string.IsNullOrWhiteSpace(searchCriteria.Ville))
                {

                    predicate = predicate.And(c => c.VILLE.Contains(searchCriteria.Ville,
                        StringComparison.InvariantCultureIgnoreCase));

                }

                if (!string.IsNullOrWhiteSpace(searchCriteria.Praticien))
                {

                    predicate = predicate.And(c => c.Collaborateur != null &&
                                                c.Collaborateur.Any(co => co.ROLE == RoleEnum.Praticien.ToString() &&
                                                    (co.NOM.Contains(searchCriteria.Praticien, StringComparison.InvariantCultureIgnoreCase) ||
                                                     co.PRENOM.Contains(searchCriteria.Praticien, StringComparison.InvariantCultureIgnoreCase))));

                }

                var cabinets = _cabinetManager.Search(predicate);
                foreach (var cabinet in cabinets)
                {

                    var toAdd = cabinet.GetCabinetDto(_collaborateurManager.GetByCabinet(cabinet.ID));

                    if (toAdd != null)
                    {
                        toReturn.Add(toAdd);
                    }

                }

                return toReturn;

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
            var cabinet = _cabinetManager.GetById(idCabinet);

            if (cabinet != null)
            {
                var collaborateurs = _collaborateurManager.GetByCabinet(cabinet.ID);
                return _cabinetManager.GetById(idCabinet).GetCabinetDto(collaborateurs);

            }

            return null;
        }
    }
}
