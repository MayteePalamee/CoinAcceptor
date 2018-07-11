using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Configuration;
namespace CoinAcceptor{

    public class Coinacceptor : SerialPortHelper, DevicesHelper
    {
        /**Initialzed**/
        private SerialPort _serialPort = new SerialPort();
        private Status status;
        /**
         * event delegate.
         **/
        public delegate void raiseEvent(String message);
        public event raiseEvent Raise = delegate { };
        /**
         * delegate method handle raise event
         **/
        protected virtual void onRaiseEvent(String message){
            raiseEvent Handler = this.Raise;
            if (Handler != null){ Handler(message);}
        }
        /**
         * connect to devices.
         **/
        public Status Connect(String command){
            status = new Status();
            try{
                /*_serialPort = Initial();
                _serialPort.Open();

                if (_serialPort.IsOpen){

                }*/
            }
            catch(Exception ex){
                status.Fault = ex.Message;
                onRaiseEvent(status.Fault);  
            }
            return status;
        }
        /**
         * send command to devices.
         **/
        public Status Transmitte(string command){
            status = new Status();
            try{

            }catch (Exception ex){
                status.Fault = ex.Message;
                onRaiseEvent(status.Fault);
            }
            return status;
        }
        /**
        * send command to devices.
        **/
        public Status Received(string command){
            status = new Status();
            try
            {

            }
            catch (Exception ex)
            {
                status.Fault = ex.Message;
                onRaiseEvent(status.Fault);
            }
            return status;
        }
        /**
         * disconnect devices.
         **/
        public Status Disconnect(string command){
            status = new Status();
            try{

            }catch (Exception ex){
                status.Fault = ex.Message;
                onRaiseEvent(status.Fault);
            }
            return status;
        }
        /**
         * enabled devices.
         **/
        public Status Enabled(){
            try{

            }catch (Exception ex){
                status.Fault = ex.Message;
                onRaiseEvent(status.Fault);
            }
            return status;
        }
        /**
         * disabled devices.
         **/
        public Status Disabled(){
            status = new Status();
            try{

            }catch (Exception ex){
                status.Fault = ex.Message;
                onRaiseEvent(status.Fault);
            }
            return status;
        }
    }
}
