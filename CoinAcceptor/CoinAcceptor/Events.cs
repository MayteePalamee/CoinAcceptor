using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor
{
    /// <summary>
    /// Handlers event response.
    /// </summary>
    public class Events : EventArgs
    {
        private readonly String _message;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public Events(String message){
            _message = message;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Message
        {
            get { return _message; }
        }
    }
}
