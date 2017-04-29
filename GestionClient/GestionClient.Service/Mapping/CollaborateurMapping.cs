using GestionClient.Data;
using GestionClient.Model.Dto.Collaborateur;
using GestionClient.Model.Enum;

namespace GestionClient.Service.Mapping
{
    static public class CollaborateurMapping
    {

        public static Collaborateur GetCollaborateur(this AssistantAddDto assistantAddDto)
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
