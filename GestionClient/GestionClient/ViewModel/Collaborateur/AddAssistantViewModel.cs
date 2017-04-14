using System;
using GestionClient.Common;
using GestionClient.Service.Interface;
using GestionClient.Model.Dto.Collaborateur;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    public class AddAssistantViewModel : BaseViewModel, IBaseViewModel
    {
        #region Properties

        public AssistantAddDto Assistant;        
        public ICommand SaveAssistantCommand { get; set; }
        public ICollaborateurService CollaborateurService { get; }
        public object Data
        {
            set
            {
                Assistant.IdCabinet = (int)value;
            }
        }
        public string Name
        {
            get
            {
                return "Ajouter un assistant";
            }
        }

        #endregion

        #region Events
        public event PageChangeHandler OnPageChange;
        #endregion

        #region Constructor

        public AddAssistantViewModel(ICollaborateurService collaborateurService)
        {
            CollaborateurService = collaborateurService;
            Assistant = new AssistantAddDto();
            SaveAssistantCommand = new RelayCommand(p => SaveAssistant());
        }

        #endregion

        #region Private methods

        private void SaveAssistant()
        {
            CollaborateurService.AddAssistant(Assistant);
            OnPageChange(this, new PageChangeEvent() { PageViewModelType = typeof(DetailCabinetViewModel) });
        }

        private void Cancel()
        {
            OnPageChange(this, new PageChangeEvent() { PageViewModelType = typeof(AcceuilViewModel) });
        }

        #endregion

    }
}
