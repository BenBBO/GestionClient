using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Common
{
    public delegate void PageChangeHandler(object myObject, PageChangeEvent myArgs);
    public class PageChangeEvent
    {
        public Type PageViewModelType;
        public object Data;
    }
}
