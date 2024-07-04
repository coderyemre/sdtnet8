﻿using SanayideDijitalTeknolijiler_net8._0;
using System;
using System.Device.Gpio;
using System.Security.Cryptography.X509Certificates;

namespace SanayideDijitalTeknolijiler_net8._0
{
    class Program
    {
        static void Main(string[] args)
        {

            LogSys.InfoLog("LogSystem running");
            Thread listenerserver_thread = new Thread(TcpServer.Listen);
            listenerserver_thread.Start();//thread olarak tcp listener

            //renk denemesi
            LogSys.GrayLog("-------------------color board-------------------");
            LogSys.SuccesLog("mutlu ferhat");
            LogSys.InfoLog("düsünceli ferhat");
            LogSys.WarnLog("gergin ferhat");
            LogSys.ErrorLog("kızgın ferhat");
            LogSys.GrayLog("-------------------color board-------------------");

            //MOTOR DENEME
            EngineDrivers.Preapare_Engine_Pins();
            string oldmessage=string.Empty;
            while(true){
                
                string message =TcpServer.GetLastMessage();
                if(message!=oldmessage){
                    if(message.Trim()=="fw"){
                    LogSys.SuccesLog("GO GO");
                    EngineDrivers.Engine_FORWARD();
                }
                else if(message.Trim()=="bw"){
                     LogSys.SuccesLog("BACK BACK");
                    EngineDrivers.Engine_BACKWARD();
                }
                else if(message.Trim()=="stop"){
                    LogSys.SuccesLog("STOP");
                    EngineDrivers.Engine_RESET();
                }
                Thread.Sleep(150);
                oldmessage=message;
                }
               
            }

        }
    }
}
