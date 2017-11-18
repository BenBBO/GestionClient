using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Model.Dto.Collaborateur
{
    public class PraticienDetailDto :  CollaborateurDetailDto
    {
        public string Email { get; set; }
        public DateTime? DateConnaissance { get; set; }
       
    }
}
