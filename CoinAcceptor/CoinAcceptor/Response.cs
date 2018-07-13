using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor
{
    public class Response
    {
        private String connect;
        private String disconnect;
        private String fault;
        private String unavailable;
        private String success;
        private String ready;

        private String proximitySensors1;
        private String proximitySensors2;
        private String acceptorSensors;
        private String unknown;
        private String coin1A;
        private String coin1B;
        private String coin2A;
        private String coin2B;
        private String coin5;
        private String coin10;

        public String Unknown
        {
            get { return unknown; }
            set { unknown = value; }
        }
        public String Coin1A
        {
            get { return coin1A; }
            set { coin1A = value; }
        }
        public String Coin1B
        {
            get { return coin1B; }
            set { coin1B = value; }
        }
        public String Coin2A
        {
            get { return coin2A; }
            set { coin2A = value; }
        }
        public String ProximitySensors1
        {
            get { return proximitySensors1; }
            set { proximitySensors1 = value; }
        }
        public String Coin2B
        {
            get { return coin2B; }
            set { coin2B = value; }
        }
        public String Coin5
        {
            get { return coin5; }
            set { coin5 = value; }
        }
        public String Coin10
        {
            get { return coin10; }
            set { coin10 = value; }
        }
        public String ProximitySensors2
        {
            get { return proximitySensors2; }
            set { proximitySensors2 = value; }
        }
        public String AcceptorSensors
        {
            get { return acceptorSensors; }
            set { acceptorSensors = value; }
        }
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
