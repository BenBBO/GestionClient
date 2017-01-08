using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GestionClient.ViewModel;

namespace GestionClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Main app = new Main();
            ShellViewModel context = new ShellViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
