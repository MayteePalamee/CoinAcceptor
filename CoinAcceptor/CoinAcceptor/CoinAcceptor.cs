using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor{

    public class CoinAcceptor {
       
        /*provides event data*/
        public delegate void eventhandle(object sender, String status);
        /*event delegate.*/
        public event eventhandle events;

        private void onConnect(String command)
        {
            eventhandle raiseEvent = events;
            Status status = new Status();
            /* try
             {

             }
             catch(Exception ex)
             {*/
            //status.Fault = ex.Message;
            status.Fault = "Connection Fault";
            raiseEvent(this, status.Fault);
            //}
        } 

        private void onDisconncet(String command)
        {
            eventhandle raiseEvent = events;
            Status status = new Status();
            /* try
             {

             }
             catch(Exception ex)
             {*/
            //status.Fault = ex.Message;
            status.Fault = "Disconnect Fault";
            raiseEvent(this, status.Fault);
            //}
        }
    }
}
