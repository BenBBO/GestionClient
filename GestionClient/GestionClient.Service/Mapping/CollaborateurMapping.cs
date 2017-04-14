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
    static public class CollaborateurMapping
    {

        public static Collaborateur GetCabinet(this AssistantAddDto assistantAddDto)
        {
            var toReturn = new Collaborateur
            {

                NOM = assistantAddDto.Nom,
                PRENOM = assistantAddDto.Prenom,
                ROLE = RoleEnum.Assistant.ToString(),
                TITRE = assistantAddDto.Titre,
                ADRESSE = assistantAddDto.Adresse,
                VILLE = assistantAddDto.Ville,
                CODE_POSTAL = assistantAddDto.CodePostal,
                TELEPHONE = assistantAddDto.Telephone,
                ID_CABINET = assistantAddDto.IdCabinet

            };

            return toReturn;

        }


        public static Collaborateur GetCabinet(this PraticienAddDto praticienAddDto)
        {
            var toReturn = new Collaborateur
            {
                ID_CABINET = praticienAddDto.IdCabinet,
                COMMENTAIRE = praticienAddDto.Commentaire,
                DATE_CONNAISSANCE = praticienAddDto.DateConnaissance,
                EMAIL = praticienAddDto.Email,
                VILLE= praticienAddDto.Ville,
                NOM = praticienAddDto.Nom,
                PRENOM = praticienAddDto.Prenom,
                ROLE = RoleEnum.Praticien.ToString(),
                TITRE = praticienAddDto.Titre,
                ADRESSE = praticienAddDto.Adresse,
                CODE_POSTAL = praticienAddDto.CodePostal,
                TELEPHONE = praticienAddDto.Telephone

            };

            return toReturn;

        }

    }
}
