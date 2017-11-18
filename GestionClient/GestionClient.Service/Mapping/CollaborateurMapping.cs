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

        public static void EditAssistant(this Collaborateur collaborateur, AssistantAddDto assistant)
        {
            collaborateur.NOM = assistant.Nom;
            collaborateur.PRENOM = assistant.Prenom;
            collaborateur.ADRESSE = assistant.Adresse;
            collaborateur.CODE_POSTAL = assistant.CodePostal;
            collaborateur.VILLE = assistant.Ville;
            collaborateur.TELEPHONE = assistant.Telephone;
        }

        public static void EditPraticien(this Collaborateur collaborateur, PraticienAddDto praticien)
        {
            collaborateur.NOM = praticien.Nom;
            collaborateur.PRENOM = praticien.Prenom;
            collaborateur.ADRESSE = praticien.Adresse;
            collaborateur.CODE_POSTAL = praticien.CodePostal;
            collaborateur.VILLE = praticien.Ville;
            collaborateur.TELEPHONE = praticien.Telephone;
            collaborateur.COMMENTAIRE = praticien.Commentaire;
            collaborateur.DATE_CONNAISSANCE = praticien.DateConnaissance;
            collaborateur.EMAIL = praticien.Email;
        }


        public static Collaborateur GetCabinet(this PraticienAddDto praticienAddDto)
        {
            var toReturn = new Collaborateur
            {
                ID_CABINET = praticienAddDto.IdCabinet,
                COMMENTAIRE = praticienAddDto.Commentaire,
                DATE_CONNAISSANCE = praticienAddDto.DateConnaissance,
                EMAIL = praticienAddDto.Email,
                VILLE = praticienAddDto.Ville,
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

        public static PraticienDetailDto GetDetailPraticien(this Collaborateur collaborateur)
        {
            var toReturn = new PraticienDetailDto();

            toReturn.FillCollaborateurDetailDto(collaborateur);            
            toReturn.Email = collaborateur.EMAIL;
            toReturn.DateConnaissance = collaborateur.DATE_CONNAISSANCE;

            return toReturn;

        }

        public static AssistantDetailDto GetDetailAssistant(this Collaborateur collaborateur)
        {
            var toReturn = new AssistantDetailDto();

            toReturn.FillCollaborateurDetailDto(collaborateur);

            return toReturn;
        }
        public static AssistantAddDto GetEditAssistant(this Collaborateur collaborateur)
        {
            var toReturn = new AssistantAddDto();

            toReturn.FillCollaborateurDetailDto(collaborateur);

            toReturn.IdCabinet = collaborateur.ID_CABINET;

            return toReturn;
        }

        public static PraticienAddDto GetEditPraticien(this Collaborateur collaborateur)
        {
            var toReturn = new PraticienAddDto();

            toReturn.FillCollaborateurDetailDto(collaborateur);

            toReturn.IdCabinet = collaborateur.ID_CABINET;
            toReturn.DateConnaissance = collaborateur.DATE_CONNAISSANCE;
            toReturn.Commentaire = collaborateur.COMMENTAIRE;
            toReturn.Email = collaborateur.EMAIL;

            return toReturn;
        }


        private static void FillCollaborateurDetailDto(this CollaborateurDetailDto collaborateur, Collaborateur source)
        {
            collaborateur.Id = source.ID;
            collaborateur.Nom = source.NOM;
            collaborateur.Prenom = source.PRENOM;
            collaborateur.Titre = source.TITRE;
            collaborateur.Telephone = source.TELEPHONE;
            collaborateur.Ville = source.VILLE;
            collaborateur.Adresse = source.ADRESSE;
            collaborateur.CodePostal = source.CODE_POSTAL;
        }
    }
}
