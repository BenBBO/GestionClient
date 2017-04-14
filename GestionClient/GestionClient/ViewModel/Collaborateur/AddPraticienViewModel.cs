using System;
using GestionClient.Common;
using GestionClient.Model.Dto.Collaborateur;
using GestionClient.Service.Interface;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    public class AddPraticienViewModel : IBaseViewModel
    {
        #region Properties
        public PraticienAddDto Praticien;
        public ICommand SavePraticienCommand { get; set; }
        public ICollaborateurService CollaborateurService { get; }
        public object Data
        {
            set
            {
                Praticien.IdCabinet = (int)value;
            }
        }
        public string Name { get; set; }
        #endregion

        #region Event

        public event PageChangeHandler OnPageChange;

        #endregion

        #region Constructor

        public AddPraticienViewModel(ICollaborateurService collaborateurService)
        {
            CollaborateurService = collaborateurService;
            Praticien = new PraticienAddDto();
            SavePraticienCommand = new RelayCommand(p => SavePraticien());

        }

        #endregion

        private void SavePraticien()
        {
            CollaborateurService.AddPraticien(Praticien);
            OnPageChange(this, new PageChangeEvent() { PageViewModelType = typeof(DetailCabinetViewModel) });
        }

    }
}