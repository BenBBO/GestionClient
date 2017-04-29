using GestionClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    public abstract class CollaborateurViewModel : BaseViewModel, IBaseViewModel
    {

        #region Events
        public event PageChangeHandler OnPageChange;
        #endregion

        #region Properties

        public abstract string Name { get; }

        protected int _IdCabinet;
        public ICommand CancelCommand { get; set; }

        public object Data
        {
            set
            {
                _IdCabinet = (int)value;
            }
        }

        #endregion

        #region Constructor
        public CollaborateurViewModel()
        {

            CancelCommand = new RelayCommand(p => LoadDetailView());

        }
        #endregion

        #region Methods
        protected void LoadDetailView()
        {
            OnPageChange(this, new PageChangeEvent()
            {
                PageViewModelType = typeof(DetailCabinetViewModel),
                Data = _IdCabinet
            });
        }

        public abstract void Initialize();
        #endregion

    }
}
