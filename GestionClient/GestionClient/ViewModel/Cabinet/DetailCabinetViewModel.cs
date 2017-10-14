using GestionClient.Common;
using GestionClient.Model.Dto.Cabinet;
using GestionClient.Model.Dto.Collaborateur;
using GestionClient.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    public class DetailCabinetViewModel : BaseViewModel, IBaseViewModel
    {

        #region Properties

        private ICabinetService cabinetService;
        private ICollaborateurService collaborateurService;
        public event PageChangeHandler OnPageChange;
        public ICommand AddPraticien { get; set; }
        public ICommand AddAssistant { get; set; }
        public ICommand Back { get; set; }
        public ICommand SelectedPraticienChangedCommand { get; set; }

        public string Name
        {
            get
            {
                return "Détail Cabinet";
            }
        }

        private CabinetDto _cabinet;
        private int _IdCabinet;
        public CabinetDto Cabinet
        {
            get
            {
                return _cabinet;
            }
            set
            {
                _cabinet = value;
                this.OnPropertyChanged("Cabinet");
            }
        }

        private PraticienDetailDto _selectedPraticien;
        public PraticienDetailDto SelectedPraticien
        {
            get
            {
                return _selectedPraticien;
            }
            set
            {
                _selectedPraticien = value;
                this.OnPropertyChanged("SelectedPraticien");
            }

        }
        public object Data
        {
            set
            {
                _IdCabinet = (int)value;
            }
        }

        #endregion

        #region Constructor

        public DetailCabinetViewModel(ICabinetService cabinetService, ICollaborateurService collaborateurService)
        {
            this.cabinetService = cabinetService;
            this.collaborateurService = collaborateurService;
            AddPraticien = new RelayCommand(p => AddPraticienMethod());
            AddAssistant = new RelayCommand(p => AddAssistantMethod());
            Back = new RelayCommand(p => BackMethod());
            SelectedPraticienChangedCommand = new RelayCommand(p => SelectPraticien(p));
        }

        #endregion

        #region Private methods

        private void AddPraticienMethod()
        {

            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(AddPraticienViewModel),
                Data = Cabinet.IdCabinet
            });

        }

        private void AddAssistantMethod()
        {

            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(AddAssistantViewModel),
                Data = Cabinet.IdCabinet
            });

        }

        private void BackMethod()
        {

            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(AcceuilViewModel)
            });

        }

        private void SelectPraticien(object p)
        {
            if (p != null)
            {
                var selectedPraticien = (PraticienDto)p;
                SelectedPraticien = collaborateurService.GetDetailPraticien(selectedPraticien.Id);
            }
        }


        public void Initialize()
        {
            _cabinet = cabinetService.GetCabinet(_IdCabinet);
        }

        #endregion

    }
}
