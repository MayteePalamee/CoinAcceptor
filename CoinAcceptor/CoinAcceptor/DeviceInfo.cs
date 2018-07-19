using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor
{
    /// <summary>
    /// Response Device Info.
    /// </summary>
    public class DeviceInfo
    {
        private String coin1A;
        private String coin1B;
        private String coin2A;
        private String coin2B;
        private String coin5;
        private String coin10;
        private String unknown;
        private String unavailable;
        private String ready;
        private String proximitySensors1;
        private String proximitySensors2;
        private String proximitySensors3;


        /// <summary>
        /// data from devices.
        /// </summary>
        public String Coin1A
        {
            get { return coin1A; }
            set { coin1A = value; }
        }
        /// <summary>
        /// data from devices.
        /// </summary>
        public String Coin1B
        {
            get { return coin1B; }
            set { coin1B = value; }
        }
        /// <summary>
        /// data from devices.
        /// </summary>
        public String Coin2A
        {
            get { return coin2A; }
            set { coin2A = value; }
        }
        /// <summary>
        /// data devices from .config
        /// </summary>
        public String Coin2B
        {
            get { return coin2B; }
            set { coin2B = value; }
        }
        /// <summary>
        /// data devices from .config
        /// </summary>
        public String Coin5
        {
            get { return coin5; }
            set { coin5 = value; }
        }
        /// <summary>
        /// data devices from .config
        /// </summary>
        public String Coin10
        {
            get { return coin10; }
            set { coin10 = value; }
        }
        /// <summary>
        /// data devices from .config
        /// </summary>
        public String ProximitySensors1
        {
            get { return proximitySensors1; }
            set { proximitySensors1 = value; }
        }
        /// <summary>
        /// data from devices.
        /// </summary>
        public String ProximitySensors2
        {
            get { return proximitySensors2; }
            set { proximitySensors2 = value; }
        }
        /// <summary>
        /// data from devices.
        /// </summary>
        public String ProximitySensors3
        {
            get { return proximitySensors3; }
            set { proximitySensors3 = value; }
        }
        /// <summary>
        /// data from devices.
        /// </summary>
        public String Unknown
        {
            get { return unknown; }
            set { unknown = value; }
        }
        /// <summary>
        /// data from devices.
        /// </summary>
        public String Unavailable
        {
            get { return unavailable; }
            set { unavailable = value; }
        }
        /// <summary>
        /// data from devices.
        /// </summary>
        public String Ready
        {
            get { return ready; }
            set { ready = value; }
        }
    }
}
