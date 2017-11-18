using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Model.Dto.Collaborateur
{
    public class CollaborateurDto
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string FormatedName
        {
            get
            {
                return $"{Titre} {Nom} {Prenom}";
            }
        }
    }
}
