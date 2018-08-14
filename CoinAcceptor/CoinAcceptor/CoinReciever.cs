using System;
using System.IO.Ports;
using System.Threading;
namespace CoinReciever{
    
    /// <summary>
    /// <para>Note : Coin Reciever Class</para>
    /// </summary>
    public class Coinreciever : SerialPortHelper
    {
        //return state
        private string _invoke = "";
        //Acknowledge event
        private delegate string _acknowledge(String e);
        private event _acknowledge _accept;
        private string _message = "";
        /// <summary>
        /// Receive return data from device
        /// </summary>
        /// <param name="e"></param>
        private string OnAccept(string e)
        {
            _message = _accept?.Invoke(e);
            return _message;
        }

        /// <summary>
        /// <para>Note : Declare the event using EventHandle for Coin Accept</para>
        /// </summary>
        public event EventHandler<CoinEvent> Reciever;
        /// <summary>
        /// <para>Note : delegate method handle raise event</para>
        /// </summary>
        protected virtual void OnReveiver(CoinEvent e)
        {
            Reciever?.Invoke(this, e);
        }

        private SerialPort _serialPort = new SerialPort();
        private InitialPort initPort;
       
        /// <summary>
        /// setting comport
        /// </summary>
        /// <param name="port">comport name</param>
        public void SetPort(String port)
        {
           initPort = new InitialPort();
           initPort.Comport = port;
           initPort.BaudRate = 9600;
           initPort.DataBits = 8;
           initPort.DtrEnable = true;

           _serialPort = Initial(initPort);
        }
        /// <summary>
        /// getter portname
        /// </summary>
        /// <returns></returns>
        public String GetPort()
        {
            return _serialPort.PortName == null ? "" : _serialPort.PortName;
        }
     
        /// <summary>
        /// <para>Note : send command to devices.</para>
        /// <para>return DevicesInfo</para>
        /// <para>Note : DevicesInfo is java Object</para>
        /// <para>Status Device : 90051103A9</para>
        /// <para>Firmware Version : 900503039B</para>
        /// </summary>
        public String CurrentStatus()
        {
            byte[] data = { };
            try
            {
                _serialPort.DataReceived -= _serialPortDataReceived;
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }

                if (_serialPort.IsOpen)
                {
                    CallbackState();
                }
            }
            catch (Exception exception)
            {
                _serialPort.Close();
                Console.WriteLine("exception : " + exception);
            }
            Console.WriteLine("current state : " + _invoke);
            _serialPort.DataReceived += _serialPortDataReceived;
            return _invoke;
        }

        /// <summary>
        /// <para>Note : Enabled to devices.</para>
        /// <para>return status</para>
        /// <para>Command Device : 9005010399</para>
        /// </summary>
        public String Open(){
            Byte[] data = { };
            try
            {
                _serialPort.DataReceived -= _serialPortDataReceived;
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
                if (_serialPort.IsOpen)
                {
                    //Enable Device
                    data = ConvertHexToByte("9005010399");
                    _serialPort.Write(data, 0, data.Length);

                    _accept += CoinInfo;
                    Thread.Sleep(100);
                    CallbackState();

                    if (_invoke.Equals(CoinState.Ready.ToString()))
                    {                        
                        _serialPort.DataReceived += _serialPortDataReceived;
                    }
                }
            }
            catch (Exception exception)
            {
                _serialPort.Close();
                Console.WriteLine("exception : " + exception);
            }
            return _invoke;
        }

        /// <summary>
        /// <para>Note : Disabled to devices.</para>
        /// <para>return success ? true : false</para>
        /// <para>Command Device : 900502039A</para>
        /// </summary>
        public String Close(){
            Byte[] data = { };
            try
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
                if (_serialPort.IsOpen)
                {
                    //Disabled Device
                    data = ConvertHexToByte("900502039A");
                    _serialPort.Write(data, 0, data.Length);

                    Thread.Sleep(100);
                    CallbackState();
                }
                _serialPort.DiscardOutBuffer();
                _serialPort.DiscardInBuffer();
                _serialPort.Close();
            }
            catch (Exception exception)
            {
                _serialPort.Close();
                Console.WriteLine("exception : " + exception);
            }
            _accept -= CoinInfo;
            _serialPort.DataReceived -= _serialPortDataReceived;
            return _invoke;
        }

        /// <para>coinIn1A : 9006120103AC</para>
        /// <para>coinIn1B : 9006120603B1</para>
        /// <para>coinIn2A : 9006120203AD</para>
        /// <para>coinIn2B : 9006120503B0</para>
        /// <para>coinIn5 : 9006120303AE</para>
        /// <para>coinIn10 : 9006120403AF</para>
        /// <para>enabled disabled : 90055003E8</para>
        private void _serialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                SerialPort sp = (SerialPort)sender;
                int count = sp.BytesToRead;
                byte[] data = new byte[count];
                sp.Read(data, 0, data.Length);

                string result = OnAccept(ConvertByteToString(data));
                OnReveiver(new CoinEvent(result));
            }
        }

        private string CoinInfo(String data)
        {
            string coin = "";
            switch (data.ToUpper())
            {
                case "9006120103AC":
                    coin = "1";
                    break;
                case "9006120603B1":
                    coin = "1";
                    break;
                case "9006120203AD":
                    coin = "2";
                    break;
                case "9006120503B0":
                    coin = "2";
                    break;
                case "9006120303AE":
                    coin = "5";
                    break;
                case "9006120403AF":
                    coin = "10";
                    break;
                case "90055003E8":
                    coin = "";
                    break;
                default:
                    coin = "";
                    break;
            }
            return coin;
        }
        private void CallbackState()
        {
            byte[] data = { };
            bool state = false;
            try
            {
                _serialPort.DataReceived -= _serialPortDataReceived;
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }

                if (_serialPort.IsOpen)
                {
                    do {
                        data = ConvertHexToByte("90051103A9");
                        _serialPort.Write(data, 0, data.Length);

                        Thread.Sleep(100);
                        state = CallState(_serialPort);
                    } while (state);
                }
            }
            catch (Exception exception)
            {
                _serialPort.Close();
                Console.WriteLine("exception : " + exception);
            }
        }

        private delegate void getStatus(string data);
        private void StateInfo(string data)
        {
            switch (data.ToUpper())
            {
                case "90051103A9":
                    _invoke = CoinState.Ready.ToString();
                    break;
                case "90051403AC":
                    _invoke = CoinState.Unavailable.ToString();
                    break;
                case "9006160103B0":
                    _invoke = CoinState.Sensor_1_problem.ToString();
                    break;
                case "9006160203B1":
                    _invoke = CoinState.Sensor_2_problem.ToString();
                    break;
                case "9006160303B2":
                    _invoke = CoinState.Sensor_3_problem.ToString();
                    break;
                default:
                    _invoke = "default";
                    break;
            }
        }
        private bool CallState(SerialPort serialPort)
        {
            byte[] rxBytes = { };
            bool status = false;
            if (serialPort.IsOpen)
            {
                serialPort.ReadTimeout = 1000;
                int count = serialPort.BytesToRead;
                if(count > 5) { status = true; }
                    int totBytesRead = 0;
                    rxBytes = new byte[count];
                    while (totBytesRead < count)
                    {
                        int bytesRead = serialPort.Read(rxBytes, 0, count - totBytesRead);
                        totBytesRead += bytesRead;
                    }
                getStatus get = new getStatus(StateInfo);
                get(ConvertByteToString(rxBytes));
            }
            return status;
        }
    }
}
