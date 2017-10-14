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
        public static CabinetDto GetCabinetDto(this Cabinet cabinet, IEnumerable<Collaborateur> collaborateurs)
        {

            if (cabinet == null) { return null; }

            CabinetDto toReturn = new CabinetDto()
            {
                IdCabinet = cabinet.ID,
                RaisonSociale = cabinet.RAISON_SOCIALE,
                Adresse = cabinet.ADRESSE,
                CodePostal = cabinet.CODE_POSTAL,
                Ville = cabinet.VILLE,
                Telephone = cabinet.TELEPHONE
            };

            //Gestion des praticiens
            if (collaborateurs != null)
            {

                toReturn.PraticienList = collaborateurs.
                    Where(c => c.ROLE == RoleEnum.Praticien.ToString()).
                    Select(c => new PraticienDto()
                    {
                        Id = c.ID,
                        Nom = c.NOM,
                        Prenom = c.PRENOM,
                        Titre = c.TITRE,
                        Telephone = c.TELEPHONE                
                    });

                toReturn.AssistantList = collaborateurs.
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
