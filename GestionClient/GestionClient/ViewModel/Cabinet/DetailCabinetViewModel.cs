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

        #region Private members

        private ICabinetService cabinetService;
        private ICollaborateurService collaborateurService;
        private int _IdCabinet;
        private CabinetDto _cabinet;
        private PraticienDetailDto _selectedPraticien;
        private AssistantDetailDto _selectedAssistant;

        #endregion
        
        #region Properties      

        public event PageChangeHandler OnPageChange;
        public event MessageDisplayHandler OnMessageDisplay;
        public ICommand AddPraticien { get; set; }
        public ICommand AddAssistant { get; set; }
        public ICommand Back { get; set; }
        public ICommand SelectedPraticienChangedCommand { get; set; }
        public ICommand SelectedAssistantChangedCommand { get; set; }
        public ICommand EditAssitantCommand { get; set; }
        public ICommand EditPraticienCommand { get; set; }        
        public string Name
        {
            get
            {
                return "Détail Cabinet";
            }
        }
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
        public AssistantDetailDto SelectedAssistant
        {
            get
            {
                return _selectedAssistant;
            }
            set
            {
                _selectedAssistant = value;
                this.OnPropertyChanged("SelectedAssistant");
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
            SelectedAssistantChangedCommand = new RelayCommand(p => SelectAssistant(p));
            EditAssitantCommand = new RelayCommand(p => EditAssistant());
            EditPraticienCommand = new RelayCommand(p => EditPraticien());

        }    

        #endregion

        #region Public methods
        public void Initialize()
        {
            _cabinet = cabinetService.GetCabinet(_IdCabinet);
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

        private void SelectAssistant(object p)
        {
            if (p != null)
            {
                var selectedAssistant= (AssistantDto)p;
                SelectedAssistant = collaborateurService.GetDetailAssistant(selectedAssistant.Id);
            }
        }

        private void EditAssistant()
        {
            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(EditAssistantViewModel),
                Data = SelectedAssistant.Id
            });
        }

        private void EditPraticien()
        {
            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(EditPraticienViewModel),
                Data = SelectedPraticien.Id
            });
        }

        #endregion

    }
}
