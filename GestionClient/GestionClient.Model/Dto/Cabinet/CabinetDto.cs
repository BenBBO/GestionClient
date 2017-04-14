using GestionClient.Model.Dto.Collaborateur;
using System;
using System.Collections.Generic;


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
        public DateTime DateDerniereIntervention { get; set; }

    }
}
