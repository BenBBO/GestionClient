using GestionClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.ViewModel
{
        
    public interface IBaseViewModel
    {

        string Name { get; }
        object Data { set; }
        event PageChangeHandler OnPageChange;

    }
           
}
