using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestionClient.Common;
using GestionClient.Model.Dto.Cabinet;
using GestionClient.Service.Interface;

namespace GestionClient.ViewModel
{
    class EditCabinetViewModel : BaseViewModel, IBaseViewModel
    {


        #region Private members

        private ICabinetService _cabinetService;
        private int _IdCabinet;
        private CabinetEditDto _cabinet;

        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return "Modification d'un cabinet";
            }
        }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public object Data
        {
            set
            {
                _IdCabinet = (int)value;
            }
        }
        #endregion

        #region Events
        public event PageChangeHandler OnPageChange;
        public event MessageDisplayHandler OnMessageDisplay;
        #endregion

        #region Constructor
        public EditCabinetViewModel(ICabinetService cabinetService)
        {
            cabinetService = _cabinetService;
            CancelCommand = new RelayCommand(p => BackToDetail());
            SaveCommand = new RelayCommand(p => SaveCabinet());

        }        
        #endregion


        private void SaveCabinet()
        {
            _cabinetService.SaveCabinet(_cabinet);
            OnMessageDisplay(this, new MessageDisplayEvent() { Message = "Les données ont été enregistrées avec succès" });
            BackToDetail();
        }

        public void Initialize()
        {
            _cabinet = _cabinetService.GetCabinetToEdit(_IdCabinet);
        }

        private void BackToDetail()
        {
            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(DetailCabinetViewModel),
                Data = _IdCabinet
            });
        }

    }
}
