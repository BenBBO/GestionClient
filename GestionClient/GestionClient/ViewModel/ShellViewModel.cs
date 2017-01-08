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
    class ShellViewModel : BaseViewModel
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

            // Add available pages
            PageViewModels.Add(new AcceuilViewModel(GetImplementation<ICabinetService>()));

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
        }

        public T GetImplementation<T>()
        {
            return kernel.Get<T>();
        }

        #endregion

    }
}
