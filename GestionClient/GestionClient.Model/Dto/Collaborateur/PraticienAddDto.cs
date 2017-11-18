using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Model.Dto.Collaborateur
{
    public class PraticienAddDto : CollaborateurDetailDto
    {
                
        public int IdCabinet { get; set; }
        public string Email { get; set; }
        public DateTime? DateConnaissance { get; set; }
        public string Commentaire { get; set; }

    }
}

