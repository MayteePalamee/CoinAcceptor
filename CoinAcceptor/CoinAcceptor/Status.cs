using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor
{
    public class Status
    {
        private String connect;
        private String disconnect;
        private String fault;
        private String unavailable;
        private String success;
        private String ready;

        public String Connect
        {
            get { return connect; }
            set { connect = value; }
        }
        public String Disconnect
        {
            get { return disconnect; }
            set { disconnect = value; }
        }
        public String Fault
        {
            get { return fault; }
            set { fault = value; }
        }
        public String Unavailable
        {
            get { return unavailable; }
            set { unavailable = value; }
        }
        public String Success
        {
            get { return success; }
            set { success = value; }
        }
        public String Ready
        {
            get { return ready; }
            set { ready = value; }
        }
    }
}
