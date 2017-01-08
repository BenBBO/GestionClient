using GestionClient.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    class AddCabinetViewModel : BaseViewModel, IBaseViewModel
    {

        private ICabinetService cabinetService;
        public ICommand SaveCabinetCommand { get; set; }

        public string Name
        {
            get
            {
                return "Ajouter un cabinet";
            }
        }

        #region Constructor

        public AddCabinetViewModel(ICabinetService cabinetService)
        {
            this.cabinetService = cabinetService;

            SaveCabinetCommand = new RelayCommand(p => SaveCabinet());

        }

        #endregion

        private void SaveCabinet()
        {
            //Todo : méthode de sauvegarde d'un cabinet
        }
    }
}
