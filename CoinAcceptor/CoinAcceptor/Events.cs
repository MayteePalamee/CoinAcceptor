using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor
{
    public class Events : EventArgs
    {
        private readonly String _message;
        public Events(String message){
            _message = message;
        }
        public String Message
        {
            get { return _message; }
        }
    }
}
