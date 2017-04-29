using GestionClient.Common;
using GestionClient.Model.Dto.Cabinet;
using GestionClient.Service.Interface;
using System.Windows.Input;
using System;

namespace GestionClient.ViewModel
{
    public class AddCabinetViewModel : BaseViewModel, IBaseViewModel
    {

        #region Properties

        private ICabinetService cabinetService;
        public event PageChangeHandler OnPageChange;

        public ICommand SaveCabinetCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CabinetAddDto Cabinet { get; set; }
        public string Name
        {
            get
            {
                return "Ajouter un cabinet";
            }
        }

        public object Data
        {
            set
            {

            }
        }

        #endregion

        #region Constructor

        public AddCabinetViewModel(ICabinetService cabinetService)
        {
            this.cabinetService = cabinetService;
            Cabinet = new CabinetAddDto();

            SaveCabinetCommand = new RelayCommand(p => SaveCabinet());
            CancelCommand = new RelayCommand(p => Cancel());

        }

        #endregion

        #region Methods

        private void SaveCabinet()
        {
            //Todo : méthode de sauvegarde d'un cabinet
            cabinetService.AddCabinet(Cabinet);
            OnPageChange(this, new PageChangeEvent() { PageViewModelType = typeof(DetailCabinetViewModel) });
        }

        private void Cancel()
        {
            OnPageChange(this, new PageChangeEvent() { PageViewModelType = typeof(AcceuilViewModel) });
        }

        public void Initialize()
        {
        }

        #endregion
    }
}
