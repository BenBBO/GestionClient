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

        public string Name
        {
            get
            {
                return "Détail Cabinet";
            }
        }

        private CabinetDto _Cabinet;
        public object Data
        {
            set
            {
                _Cabinet = (CabinetDto)value;
            }
        }

        #endregion

        #region Constructor

        public DetailCabinetViewModel(ICabinetService cabinetService)
        {
            this.cabinetService = cabinetService;
        }

        #endregion

        #region Private methods





        #endregion

    }
}
