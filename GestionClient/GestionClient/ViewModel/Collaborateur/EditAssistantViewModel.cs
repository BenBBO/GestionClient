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
    public class EditAssistantViewModel : BaseViewModel, IBaseViewModel        
    {

        #region Private members
        private ICollaborateurService _collaborateurService;
        private int _IdCollaborateur;
        private AssistantAddDto _assistant;
        #endregion

        #region Properties
        public AssistantAddDto Assistant
        {
            get
            {
                return _assistant;
            }
            set
            {
                _assistant = value;
                this.OnPropertyChanged("Assistant");
            }
        }
        public object Data
        {
            set
            {
                _IdCollaborateur = (int)value;
            }
        }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public string Name
        {
            get
            {
                return "Modification d'un(e) assistant(e)";
            }
        }
        public event PageChangeHandler OnPageChange;
        public event MessageDisplayHandler OnMessageDisplay;
        #endregion

        #region Constructor
        public EditAssistantViewModel(ICollaborateurService collaborateurService)
        {
            _collaborateurService = collaborateurService;
            CancelCommand = new RelayCommand(p => BackToDetail());
            SaveCommand = new RelayCommand(p => SaveAssistant());
        }    
        #endregion
        
        public void Initialize()
        {
            _assistant = _collaborateurService.GetEditAssistant(_IdCollaborateur);
        }
        
        private void BackToDetail()
        {
            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(DetailCabinetViewModel),
                Data = Assistant.IdCabinet
            });
        }

        private void SaveAssistant()
        {
            _collaborateurService.SaveAssistant(Assistant);            
            OnMessageDisplay(this, new MessageDisplayEvent() { Message = "Les données ont été enregistrées avec succès" });
        }

    }
}
