using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor
{
    /// <summary>
    /// Response data Object.
    /// </summary>
    public class Stated
    {
        private Boolean state;
        private String message;
        /// <summary>
        /// 
        /// </summary>
        public Boolean State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// description 
        /// </summary>
        public String Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
