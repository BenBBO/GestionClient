using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionClient.Model.Dto.Collaborateur
{
    public class CollaborateurDetailDto : CollaborateurDto
    {
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }        
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
        public string FormatedVille
        {
            get
            {
                return $"{CodePostal} - {Ville}";
            }
        }
    }
}
