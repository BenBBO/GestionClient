using GestionClient.Common;
using GestionClient.Service.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionClient.ViewModel
{
    public class ShellViewModel : BaseViewModel
    {

        #region Fields

        private StandardKernel kernel;
        private ICommand changePageCommand;
        private IBaseViewModel currentPageViewModel;
        private List<IBaseViewModel> pageViewModels;

        #endregion

        #region Constructor
        public ShellViewModel()
        {
            //Load Ninject Kernel
            kernel = new StandardKernel();
            kernel.Load(new List<Ninject.Modules.INinjectModule> { new Bindings() });

            //Load Implementations
            ICabinetService cabinetService = GetImplementation<ICabinetService>();
            ICollaborateurService collaborateurService = GetImplementation<ICollaborateurService>();


            // Add available pages
            AddPageViewModel(new AcceuilViewModel(cabinetService));
            AddPageViewModel(new AddCabinetViewModel(cabinetService));
            AddPageViewModel(new DetailCabinetViewModel(cabinetService));
            AddPageViewModel(new AddAssistantViewModel(collaborateurService));
            AddPageViewModel(new AddPraticienViewModel(collaborateurService));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }
        #endregion

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (changePageCommand == null)
                {
                    changePageCommand = new RelayCommand(p => ChangeViewModel((IBaseViewModel)p));
                }

                return changePageCommand;
            }
        }

        public List<IBaseViewModel> PageViewModels
        {
            get
            {
                if (pageViewModels == null)
                    pageViewModels = new List<IBaseViewModel>();

                return pageViewModels;
            }
        }

        public IBaseViewModel CurrentPageViewModel
        {
            get
            {
                return currentPageViewModel;
            }
            set
            {
                if (currentPageViewModel != value)
                {
                    currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IBaseViewModel viewModel)
        {

            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);

            CurrentPageViewModel.Initialize();

        }

        private void ChangeViewModel(Type viewModel, object Data)
        {

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm.GetType() == viewModel);
            CurrentPageViewModel.Data = Data;

            CurrentPageViewModel.Initialize();

        }

        public T GetImplementation<T>()
        {
            return kernel.Get<T>();
        }

        private void AddPageViewModel(IBaseViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }


            viewModel.OnPageChange += ViewModel_OnPageChange;

            PageViewModels.Add(viewModel);

        }

        private void ViewModel_OnPageChange(object sender, PageChangeEvent e)
        {
            ChangeViewModel(e.PageViewModelType, e.Data);
        }

        #endregion

    }
}
