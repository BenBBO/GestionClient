using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClient.Common;
using GestionClient.Service.Interface;
using GestionClient.Model.Dto.Collaborateur;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    public class EditPraticienViewModel : BaseViewModel, IBaseViewModel
    {

        #region Private members
        private ICollaborateurService _collaborateurService;
        private int _IdCollaborateur;
        private PraticienAddDto _praticien;
        #endregion

        #region Properties
        public PraticienAddDto Praticien
        {
            get
            {
                return _praticien;
            }
            set
            {
                _praticien = value;
                this.OnPropertyChanged("Praticien");
            }
        }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public object Data
        {
            set
            {
                _IdCollaborateur = (int)value;
            }
        }
        public string Name
        {
            get
            {
                return "Modification d'un(e) praticien(ne)";
            }
        }
        public event PageChangeHandler OnPageChange;

        public event MessageDisplayHandler OnMessageDisplay;

        #endregion



        #region Constructor
        public EditPraticienViewModel(ICollaborateurService collaborateurService)
        {
            _collaborateurService = collaborateurService;
            CancelCommand = new RelayCommand(p => BackToDetail());
            SaveCommand = new RelayCommand(p => SavePraticien());
        }
        #endregion


        private void BackToDetail()
        {
            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(DetailCabinetViewModel),
                Data = Praticien.IdCabinet
            });
        }

        private void SavePraticien()
        {
            _collaborateurService.SavePraticien(Praticien);
            OnMessageDisplay(this, new MessageDisplayEvent() { Message = "Les données ont été enregistrées avec succès" });
        }

        public void Initialize()
        {
            _praticien= _collaborateurService.GetEditPraticien(_IdCollaborateur);
        }
    }
}
