using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Common
{
    public delegate void MessageDisplayHandler(object myObject, MessageDisplayEvent myArgs);
    public class MessageDisplayEvent
    {
        
        public string Message;
    }
}
