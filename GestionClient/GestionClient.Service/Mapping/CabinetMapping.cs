using GestionClient.Data;
using GestionClient.Model.Dto.Cabinet;
using GestionClient.Model.Dto.Collaborateur;
using GestionClient.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Service.Mapping
{
    static public class CabinetMapping
    {

        /// <summary>
        /// Mapping d'un Cabinet vers un CabinetDto
        /// </summary>
        /// <param name="cabinet">Données du cabinet</param>
        /// <returns>Cabinet Dto</returns>
        public static CabinetDto GetCabinetDto(this Cabinet cabinet)
        {

            if (cabinet == null) { return null; }

            CabinetDto toReturn = new CabinetDto()
            {
                IdCabinet = cabinet.ID,
                RaisonSociale = cabinet.RAISON_SOCIALE,
                Adresse = cabinet.ADRESSE,
                CodePostal = cabinet.CODE_POSTAL,
                Ville = cabinet.VILLE
            };

            //Gestion des praticiens
            if (cabinet.Collaborateur != null)
            {

                toReturn.PraticienList = cabinet.Collaborateur.
                    Where(c => c.ROLE == RoleEnum.Praticien.ToString()).
                    Select(c => new PraticienDto()
                    {
                        Nom = c.NOM,
                        Prenom = c.PRENOM,
                        Titre = c.TITRE
                    });

                toReturn.AssistantList = cabinet.Collaborateur.
                    Where(c => c.ROLE == RoleEnum.Assistant.ToString()).
                    Select(c => new AssistantDto()
                    {
                        Nom = c.NOM,
                        Prenom = c.PRENOM,
                        Titre = c.TITRE
                    });
            }

            return toReturn;

        }

        /// <summary>
        /// Mapping d'une liste de cabinet vers une liste de CabinetDto
        /// </summary>
        /// <param name="cabinetList">Liste de cabinets</param>
        /// <returns>Liste de CabinetDto</returns>
        public static IEnumerable<CabinetDto> GetCabinetDto(this IEnumerable<Cabinet> cabinetList)
        {
            List<CabinetDto> toReturn = new List<CabinetDto>();

            foreach (Cabinet item in cabinetList)
            {

                toReturn.Add(item.GetCabinetDto());

            }

            return toReturn;

        }

        public static Cabinet GetCabinet(this CabinetAddDto cabinetDto)
        {
            var toReturn = new Cabinet
            {

                RAISON_SOCIALE = cabinetDto.RaisonSociale,
                ADRESSE = cabinetDto.Adresse,
                CODE_POSTAL = cabinetDto.CodePostal,
                VILLE = cabinetDto.Ville,
                COMMENTAIRE = cabinetDto.Commentaire,
                TELEPHONE = cabinetDto.Telephone
            };

            if (!string.IsNullOrWhiteSpace(cabinetDto.Siret))
            {
                int intSiret;
                if (int.TryParse(cabinetDto.Siret, out intSiret))
                {
                    toReturn.SIRET = intSiret;
                }

            }

            return toReturn;

        }

    }
}
