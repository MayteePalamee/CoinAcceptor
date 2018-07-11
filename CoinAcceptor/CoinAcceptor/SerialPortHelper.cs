using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CoinAcceptor
{
    public class SerialPortHelper : ConvertHelper
    {
        /**
         * Initial SerialPort
         **/
        protected SerialPort Initial(){
            SerialPort _serialport = new SerialPort();
            var config = new System.Configuration.AppSettingsReader();

            _serialport.PortName = config.GetValue("PortName", typeof(string)).ToString();
            _serialport.BaudRate = int.Parse(config.GetValue("BaudRate", typeof(string)).ToString());
            _serialport.DataBits = int.Parse(config.GetValue("DataBits", typeof(string)).ToString());
            _serialport.StopBits = StopBits.One;
            _serialport.DtrEnable = bool.Parse(config.GetValue("DtrEnable", typeof(string)).ToString());
            _serialport.Parity = Parity.None;

            return _serialport;
        }

        /**
         * Receive data from SerialPort
         **/

        /**
         * Send data to SerialPort
         **/

        /**
         * Convert command byte.
         **/
    }
}
