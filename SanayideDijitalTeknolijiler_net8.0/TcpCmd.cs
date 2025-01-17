using System.ComponentModel;
using System.Device.Gpio;
using SanayideDijitalTeknolijiler_net8._0;
using Swan.Logging;
using Unosquare.RaspberryIO.Abstractions;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public static class TcpCmd
    {
        internal static void Executor(){
            LogSys.InfoLog("Executor started");
            string oldmessage=string.Empty;
            while(true){
                string message =TcpServer.GetLastMessage();
                if(message!=oldmessage){
                    if(message=="fw"){
                    LogSys.SuccesLog("GO GO");
                    EngineDrivers.Engine_FORWARD();
                }
                else if(message=="bw"){
                     LogSys.SuccesLog("BACKWARD");
                    EngineDrivers.Engine_BACKWARD();
                }
                else if(message=="lf"){
                    LogSys.SuccesLog("LEFT");
                }
                else if(message=="rg"){
                    LogSys.SuccesLog("RIGHT");
                    EngineDrivers.Engine_RIGHT();
                }
                else if(message=="stop"){
                    LogSys.SuccesLog("STOP");
                    EngineDrivers.Engine_RESET();
                }
                Thread.Sleep(150);
                oldmessage=message;
                }
               
            }
        }
        internal static void ManuelExecution(string message){
           
                bool lst1=false,lst2=false,lst3=false,lst4=false;
                if(message=="fw"){
                    LogSys.SuccesLog("GO GO");
                    EngineDrivers.Engine_FORWARD();
                }
                else if(message=="bw"){
                    LogSys.SuccesLog("BACKWARD");
                    EngineDrivers.Engine_BACKWARD();
                }
                else if(message=="lf"){
                    LogSys.SuccesLog("LEFT");
                }
                else if(message=="rg"){
                    LogSys.SuccesLog("RIGHT");
                    EngineDrivers.Engine_RIGHT();
                }
                else if(message=="stop"){
                    LogSys.SuccesLog("STOP");
                    EngineDrivers.Engine_RESET();
                }
                else if(message=="distance"){
                    LogSys.SuccesLog(DistanceSens.GetDistance().ToString());
                }//MANUEL PIN CONTROL
                else if(message.Contains("spc")){
                    string local =message.Replace("spc","").Trim();
                    LogSys.SuccesLog($"Line {local} is "+TCRT5000.SpesificLineRead(Convert.ToInt32(local)).ToString());
                }
                else if(message.Contains("pin1")){
                     EngineDrivers.pin1=Convert.ToInt32(message.Replace("pin1","").Trim());
                }
                else if(message.Contains("pin2")){
                     EngineDrivers.pin2=Convert.ToInt32(message.Replace("pin2","").Trim());
                }
                else if(message.Contains("pin3")){
                     EngineDrivers.pin3=Convert.ToInt32(message.Replace("pin3","").Trim());
                }
                else if(message.Contains("pin4")){
                     EngineDrivers.pin4=Convert.ToInt32(message.Replace("pin4","").Trim());
                }
                else if(message.Contains("u_pin")){
                    string cutted_l=message.Replace("u_pin","").Trim();
                        if(GC.ReadPin(Convert.ToInt16(cutted_l))==1){
                            GC.Write(Convert.ToInt32(cutted_l),PinValue.High);
                            LogSys.SuccesLog(cutted_l+" set to high");
                        }
                        else{
                             GC.Write(Convert.ToInt32(cutted_l),PinValue.Low);
                            LogSys.SuccesLog(cutted_l+" set to low");
                        }
                }
                Thread.Sleep(150);
               
                
        }
    }
}