using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Model.Dto.Collaborateur
{
    public class PraticienDetailDto : PraticienDto
    {
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public DateTime? DateConnaissance { get; set; }
        public string Ville { get; set; }

        public string FormatedVille
        {
            get
            {
                return $"{CodePostal} - {Ville}";
            }
        }

       
    }
}
