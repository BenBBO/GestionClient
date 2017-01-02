using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using GestionClient.Service.Interface;
using GestionClient.Service;
using GestionClient.Manager.Interface;
using GestionClient.Manager;

namespace GestionClient
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {
            //Hum, du coup l'UI est obligé de référencer le manager ...
            Bind<ICabinetManager>().To<CabinetManager>();
            Bind<ICabinetService>().To<CabinetService>();
        }
    }
}
