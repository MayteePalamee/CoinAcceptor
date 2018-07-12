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
        /**
        * event delegate.
        **/
        /*public delegate void EventHandler(object sender, Events message);
          public event EventHandler Raise = delegate { };*/
        // Declare the event using EventHandler<T>
        public event EventHandler<Events> RaiseEvents;

        /**Initialzed**/
        private SerialPort _serialPort = new SerialPort();
        private Status status;
        /**
         * delegate method handle raise event
         **/
        protected virtual void OnRaiseEvent(Events e){
            RaiseEvents?.Invoke(this, e);
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
                status.Success = "connect On Connect!";
                OnRaiseEvent(new Events(status.Success));
            }
            catch(Exception ex){
                status.Fault = ex.Message;
                OnRaiseEvent(new Events(status.Fault));  
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
                //OnRaiseEvent(status.Fault);
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
                //OnRaiseEvent(status.Fault);
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
                //OnRaiseEvent(status.Fault);
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
                //OnRaiseEvent(status.Fault);
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
                //OnRaiseEvent(status.Fault);
            }
            return status;
        }

        /**
         * coin-acceptor sensor1.
         **/
        public Status CoinAcceptorSensor1()
        {
            status = new Status();
            try
            {

            }
            catch (Exception ex)
            {
                status.Fault = ex.Message;
                //OnRaiseEvent(status.Fault);
            }
            return status;
        }
        /**
         * coin-acceptor sensor2.
         **/
        public Status CoinAcceptorSensor2()
        {
            status = new Status();
            try
            {

            }
            catch (Exception ex)
            {
                status.Fault = ex.Message;
                //OnRaiseEvent(status.Fault);
            }
            return status;
        }
        /**
         * coin-acceptor sensor3.
         **/
        public Status CoinAcceptorSensor3()
        {
            status = new Status();
            try
            {

            }
            catch (Exception ex)
            {
                status.Fault = ex.Message;
                //OnRaiseEvent(status.Fault);
            }
            return status;
        }
    }
}
