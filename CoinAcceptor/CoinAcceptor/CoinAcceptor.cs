using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Configuration;
namespace CoinAcceptor{
    /// <summary>
    /// <para>Note : Coin Acceptor Class</para>
    /// </summary>
    public class Coinacceptor : SerialPortHelper
    {
        /// <summary>
        /// <para>Note : Declare the event using EventHandle for Message</para>
        /// </summary>
        public event EventHandler<Events> MessageEvents;
        /// <summary>
        /// <para>Note : Declare the event using EventHandle for Coin Accept</para>
        /// </summary>
        public event EventHandler<Events> CoinAcceptorEvent;
        /// <summary>
        /// <para>Note : delegate method handle raise event</para>
        /// </summary>
        protected virtual void OnMessage(Events e){
            MessageEvents?.Invoke(this, e);
        }
        /// <summary>
        /// <para>Note : delegate method handle raise event</para>
        /// </summary>
        protected virtual void OnCoinAcceptor(Events e)
        {
            CoinAcceptorEvent?.Invoke(this, e);
        }

        private SerialPort _serialPort = new SerialPort();
        private Response response;

        /// <summary>
        /// <para>Note : connect to devices.</para>
        /// <para>return success ? true : false</para>
        /// </summary>
        public Boolean Connect(){
            bool result = false;
            try
            {
                _serialPort = Initial();
                if (_serialPort.IsOpen){
                    _serialPort.DataReceived += CoinacceptorDataReceived;
                }
                OnMessage(new Events("connect"));
            }
            catch(Exception ex){
                OnMessage(new Events(ex.Message));  
            }
            return result;
        }
        /// <summary>
        /// <para>Note : receive data from devices</para>
        /// <para>coinIn1A : 9006120103AC</para>
        /// <para>coinIn1B : 9006120603B1</para>
        /// <para>coinIn2A : 9006120203AD</para>
        /// <para>coinIn2B : 9006120503B0</para>
        /// <para>coinIn5 : 9006120303AE</para>
        /// <para>coinIn10 : 9006120403AF</para>
        /// <para>unknown : 90055003E8</para>
        /// <para>ready : 90051103A9</para>
        /// <para>unavailable : 90051403AC</para>
        /// <para>sensor1Exception : 9006160103B0</para>
        /// <para>sensor2Exception : 9006160203B1</para>
        /// <para>sensor3Exception : 9006160308B2</para>
        /// </summary>
        private void CoinacceptorDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serial = (SerialPort)sender;
            string received = serial.ReadExisting();
            /*
             * something code
             */
            OnCoinAcceptor(new Events("received"));
        }

        /// <summary>
        /// <para>Note : send command to devices.</para>
        /// <para>return DevicesInfo</para>
        /// <para>Note : DevicesInfo is java Object</para>
        /// <para>Enabled Device : 9005010399</para>
        /// <para>Disabled Device : 900502039A</para>
        /// <para>Status Device : 90051103A9</para>
        /// <para>Firmware Version : 900503039B</para>
        /// </summary>
        public Response Transmitte(string command){
            response = new Response();
            try
            {

                response.State = true;
            }
            catch (Exception ex){
                response.Message = ex.Message;
                response.State = false;
                OnMessage(new Events(response.Message));
            }
            return response;
        }

        /// <summary>
        /// <para>Note : Enabled to devices.</para>
        /// <para>return success ? true : false</para>
        /// <para>Enabled Device : 9005010399</para>
        /// </summary>
        public Boolean Enabled(){
            bool result = false;
            try {

            }catch (Exception ex){
                OnMessage(new Events(ex.Message));
            }
            return result;
        }
        /// <summary>
        /// <para>Note : Disabled to devices.</para>
        /// <para>return success ? true : false</para>
        /// <para>Enabled Device : 900502039A</para>
        /// </summary>
        public Boolean Disabled(){
            bool result = false;
            try{

            }catch (Exception ex){
                OnMessage(new Events(ex.Message));
            }
            return result;
        }
        /// <summary>
        /// <para>Note : Disconnect Devices</para>
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean Disconnect()
        {
            bool result = false;
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    result = true;
                }
            }
            catch(Exception e)
            {
                OnMessage(new Events(e.Message));
            }
            return result;
        }
    }
}
