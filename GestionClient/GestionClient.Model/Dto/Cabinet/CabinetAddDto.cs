using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Model.Dto.Cabinet
{
    public class CabinetAddDto
    {

        public string RaisonSociale { get; set; }
        public string Siret { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Commentaire { get; set; }

    }
}
