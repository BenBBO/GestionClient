using GestionClient.Common;
using GestionClient.Service.Interface;
using GestionClient.Model.Dto.Collaborateur;
using System.Windows.Input;
using System;

namespace GestionClient.ViewModel
{
    public class AddAssistantViewModel : CollaborateurViewModel
    {
        #region Properties

        public AssistantAddDto Assistant { get; set; }
        public ICommand SaveAssistantCommand { get; set; }
        public ICollaborateurService CollaborateurService { get; }

        public override string Name
        {
            get
            {
                return "Ajouter un assistant";
            }
        }

        #endregion

        #region Constructor

        public AddAssistantViewModel(ICollaborateurService collaborateurService) : base()
        {
            CollaborateurService = collaborateurService;
            SaveAssistantCommand = new RelayCommand(p => SaveAssistant());
        }

        #endregion

        #region Methods

        public override void Initialize()
        {
            Assistant = new AssistantAddDto();
        }

        private void SaveAssistant()
        {
            Assistant.IdCabinet = _IdCabinet;
            CollaborateurService.AddAssistant(Assistant);
            LoadDetailView();
            DisplayMessage("L'assistant à été ajouté avec succès");
        }

        

        #endregion
    }
}

