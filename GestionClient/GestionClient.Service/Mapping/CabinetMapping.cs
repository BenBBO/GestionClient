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
                Telephone = cabinet.TELEPHONE,
                Email = cabinet.EMAIL
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
                        Titre = c.TITRE
                    });

                toReturn.AssistantList = collaborateurs.
                    Where(c => c.ROLE == RoleEnum.Assistant.ToString()).
                    Select(c => new AssistantDto()
                    {
                        Id = c.ID,
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

        public static CabinetEditDto GetCabinetEditDto(this Cabinet cabinet)
        {
            if (cabinet == null) { return null; }

            var toReturn = new CabinetEditDto()
            {
                IdCabinet = cabinet.ID,
                RaisonSociale = cabinet.RAISON_SOCIALE,
                Adresse = cabinet.ADRESSE,
                CodePostal = cabinet.CODE_POSTAL,
                Ville = cabinet.VILLE,
                Telephone = cabinet.TELEPHONE,
                Commentaire = cabinet.COMMENTAIRE,
                Email = cabinet.EMAIL
            };

            if (cabinet.SIRET.HasValue)
            {
                toReturn.Siret = cabinet.SIRET.Value.ToString();
            }

            return toReturn;

        }

        public static void FillEditCabinet(this Cabinet cabinet, CabinetEditDto editData)
        {
            cabinet.ADRESSE = editData.Adresse;
            cabinet.CODE_POSTAL = editData.CodePostal;
            cabinet.COMMENTAIRE = editData.Commentaire;
            cabinet.RAISON_SOCIALE = editData.RaisonSociale;
            cabinet.TELEPHONE = editData.Telephone;
            cabinet.VILLE = editData.Ville;
            cabinet.EMAIL = editData.Email;

            if (!string.IsNullOrWhiteSpace(editData.Siret))
            {
                int intSiret;
                if (int.TryParse(editData.Siret, out intSiret))
                {
                    cabinet.SIRET = intSiret;
                }

            }

        }

    }
}
