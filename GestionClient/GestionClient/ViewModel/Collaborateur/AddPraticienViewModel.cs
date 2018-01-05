using System;
using GestionClient.Common;
using GestionClient.Model.Dto.Collaborateur;
using GestionClient.Service.Interface;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    public class AddPraticienViewModel : CollaborateurViewModel
    {
        #region Properties
        public PraticienAddDto Praticien { get; set; }
        public ICommand SavePraticienCommand { get; set; }
        public ICollaborateurService CollaborateurService { get; }

        public override string Name { get; }
        #endregion

        #region Constructor

        public AddPraticienViewModel(ICollaborateurService collaborateurService) : base()
        {
            CollaborateurService = collaborateurService;
            SavePraticienCommand = new RelayCommand(p => SavePraticien());
        }

        #endregion

        #region Methods

        private void SavePraticien()
        {
            Praticien.IdCabinet = _IdCabinet;
            CollaborateurService.AddPraticien(Praticien);
            LoadDetailView();
            DisplayMessage("Le praticien à été ajouté avec succès");
         }

        public override void Initialize()
        {
            Praticien = new PraticienAddDto();
        }

        #endregion

    }
}