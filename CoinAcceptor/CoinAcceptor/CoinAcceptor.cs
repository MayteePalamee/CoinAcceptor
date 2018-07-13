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
        * Declare the event using EventHandler<T>
        **/

        public event EventHandler<Events> RaiseEvents;

        /**
         * delegate method handle raise event
         **/
        protected virtual void OnRaiseEvent(Events e){
            RaiseEvents?.Invoke(this, e);
        }

        /**Initialzed**/
        private SerialPort _serialPort = new SerialPort();
        private Response response;
        /**
         * connect to devices.
         **/
        public Response Connect(){
            response = new Response();
            try{
                /*_serialPort = Initial();
                _serialPort.Open();

                if (_serialPort.IsOpen){

                }*/
                response.Success = "connect On Connect!";
                OnRaiseEvent(new Events(response.Success));
            }
            catch(Exception ex){
                response.Fault = ex.Message;
                OnRaiseEvent(new Events(response.Fault));  
            }
            return response;
        }
        /**
         * send command to devices.
         **/
        public Response Transmitte(string command){
            response = new Response();
            try{

            }catch (Exception ex){
                response.Fault = ex.Message;
                OnRaiseEvent(new Events(response.Fault));
            }
            return response;
        }
        /**
        * send command to devices.
        **/
        public Response Received(){
            response = new Response();
            try
            {

            }
            catch (Exception ex)
            {
                response.Fault = ex.Message;
                OnRaiseEvent(new Events(response.Fault));

            }
            return response;
        }
        /**
         * disconnect devices.
         **/
        public Response Disconnect(){
            response = new Response();
            try{

            }catch (Exception ex){
                response.Fault = ex.Message;
                OnRaiseEvent(new Events(response.Fault));
            }
            return response;
        }
        /**
         * enabled devices.
         **/
        public Response Enabled(){
            try{

            }catch (Exception ex){
                response.Fault = ex.Message;
                OnRaiseEvent(new Events(response.Fault));
            }
            return response;
        }
        /**
         * disabled devices.
         **/
        public Response Disabled(){
            response = new Response();
            try{

            }catch (Exception ex){
                response.Fault = ex.Message;
                OnRaiseEvent(new Events(response.Fault));
            }
            return response;
        }

        public Response Parallel(string command)
        {
            response = new Response();
            try
            {

            }
            catch (Exception ex)
            {
                response.Fault = ex.Message;
                OnRaiseEvent(new Events(response.Fault));
            }
            return response;
        }
    }
}
