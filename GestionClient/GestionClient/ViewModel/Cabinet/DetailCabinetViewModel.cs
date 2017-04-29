using GestionClient.Common;
using GestionClient.Model.Dto.Cabinet;
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
        public event PageChangeHandler OnPageChange;
        public ICommand AddPraticien { get; set; }
        public ICommand AddAssistant { get; set; }

        public string Name
        {
            get
            {
                return "Détail Cabinet";
            }
        }

        private CabinetDto _Cabinet;
        private int _IdCabinet;
        public CabinetDto Cabinet
        {
            get { return _Cabinet; }
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

        public DetailCabinetViewModel(ICabinetService cabinetService)
        {
            this.cabinetService = cabinetService;
            AddPraticien = new RelayCommand(p => AddPraticienMethod());
            AddAssistant = new RelayCommand(p => AddAssistantMethod());
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

        public void Initialize()
        {
            _Cabinet = cabinetService.GetCabinet(_IdCabinet);
        }

        #endregion

    }
}
