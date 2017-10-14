using GestionClient.Model.Dto.Collaborateur;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GestionClient.Model.Dto.Cabinet
{
    public class CabinetDto
    {
        public int IdCabinet { get; set; }
        public string RaisonSociale { get; set; }
        public IEnumerable<PraticienDto> PraticienList { get; set; }
        public IEnumerable<AssistantDto> AssistantList { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        
        public string FormatedVille
        {
            get {
                return $"{CodePostal} - {Ville}";
            }
        }

        public string FormatedTelephone
        {
            get
            {
                if (Telephone == null)
                    return string.Empty;

                switch (Telephone.Length)
                {
                   
                    case 10:
                        return Regex.Replace(Telephone, @"(\d{2})(\d{2})(\d{2})(\d{2})(\d{2})", "$1.$2.$3.$4.$5");                
                    default:
                        return Telephone;
                }
            }
        }

        public DateTime DateDerniereIntervention { get; set; }

    }
}
