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
    public class AcceuilViewModel : BaseViewModel, IBaseViewModel
    {

        #region Properties

        private ICabinetService cabinetService;
        private IEnumerable<CabinetDto> cabinetList;
        public event PageChangeHandler OnPageChange;
        public event MessageDisplayHandler OnMessageDisplay;


        public IEnumerable<CabinetDto> CabinetList
        {
            get { return cabinetList; }
            set
            {
                cabinetList = value;
                this.OnPropertyChanged("CabinetList");
            }
        }
        public string SearchedRaisonSociale { get; set; }
        public string SearchedVille { get; set; }
        public string SearchedPraticien { get; set; }
        public ICommand AddCabinet { get; set; }
        public ICommand SearchCabinet { get; set; }
        public ICommand SelectedItemChangedCommand { get; set; }

        public string Name
        {
            get
            {
                return "Accueil";
            }
        }
        public object Data { get; set; }

        #endregion

        #region Constructor

        public AcceuilViewModel(ICabinetService cabinetService)
        {
            this.cabinetService = cabinetService;
            refreshCabinets();
        }

        #endregion

        #region Private methods

        private void refreshCabinets()
        {
            CabinetList = cabinetService.GetCabinets();
            SearchCabinet = new RelayCommand(p => SearchMethod());
            AddCabinet = new RelayCommand(p => AddCabinetMethod());
            SelectedItemChangedCommand = new RelayCommand(p => SelectCabinet(p));
        }

        private void SelectCabinet(object p)
        {
            if (p != null)
            {
                var selectedCabinet = (CabinetDto)p;
                OnPageChange(this, new PageChangeEvent()
                {
                    PageViewModelType = typeof(DetailCabinetViewModel),
                    Data = selectedCabinet.IdCabinet
                });
            }
        }

        private void AddCabinetMethod()
        {
            OnPageChange(this, new PageChangeEvent() { PageViewModelType = typeof(AddCabinetViewModel) });
        }

        private void SearchMethod()
        {

            CabinetSearchDto searchArgument = new CabinetSearchDto()
            {
                RaisonSociale = SearchedRaisonSociale,
                Ville = SearchedVille,
                Praticien = SearchedPraticien
            };

            CabinetList = cabinetService.GetCabinets(searchArgument);

        }

        public void Initialize()
        {
            refreshCabinets();
        }

        #endregion

    }
}
