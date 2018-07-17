using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Xml;
using System.Reflection;

namespace CoinAcceptor
{
    public class SerialPortHelper : ConvertHelper
    {
        /**
         * Initial SerialPort
         **/
        protected SerialPort Initial(){
            SerialPort _serialport = new SerialPort();

            /** read from app.config**/
            var config = new System.Configuration.AppSettingsReader();

            _serialport.PortName = config.GetValue("PortName", typeof(string)).ToString();
            _serialport.BaudRate = int.Parse(config.GetValue("BaudRate", typeof(string)).ToString());
            _serialport.DataBits = int.Parse(config.GetValue("DataBits", typeof(string)).ToString());
            _serialport.StopBits = StopBits.One;
            _serialport.DtrEnable = bool.Parse(config.GetValue("DtrEnable", typeof(string)).ToString());
            _serialport.Parity = Parity.None;
            return _serialport;
        }

        /*XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("CoinAcceptor.CoinAcceptor.xml"));
            XmlNodeList nodelist = xDoc.SelectNodes("/serialport");
            foreach (XmlNode node in nodelist)
            {
                System.Console.WriteLine(node.SelectSingleNode("PortName").InnerText);
                _serialport.PortName = node.SelectSingleNode("PortName").InnerText;
                _serialport.BaudRate = int.Parse(node.SelectSingleNode("BaudRate").InnerText);
                _serialport.DataBits = int.Parse(node.SelectSingleNode("DataBits").InnerText);
                _serialport.StopBits = StopBits.One;
                _serialport.DtrEnable = bool.Parse(node.SelectSingleNode("DtrEnable").InnerText);
                _serialport.Parity = Parity.None;
            }*/
    }
}
