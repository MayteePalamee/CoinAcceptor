using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor{

    public class coinacceptor {
        /*event delegate.*/
        //public event EventHandler<EventHandle> onconnect;
        public delegate void MyEventHandler(object sender, String args);
        public event MyEventHandler onconnect = delegate { };
        /*delegate method handle event*/
        protected virtual void onConnect(String e)
        {
            MyEventHandler handler = this.onconnect;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void connect(String command)
        {
            Status status = new Status();
            try
             {

             }
             catch(Exception ex)
             {
                status.Fault = ex.Message;
                //status.Fault = "Connection Fault : " + command;
                /*raise event*/
                onConnect(status.Fault);
            }
        }

    }
}
