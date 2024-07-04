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
            GC.PreparePin(2,PinMode.Output);
            GC.PreparePin(3,PinMode.Output);
            GC.PreparePin(20,PinMode.Output);
            GC.PreparePin(21,PinMode.Output);
            GC.Write(2,PinValue.High);
            GC.Write(3,PinValue.Low);
            GC.Write(20,PinValue.High);
            GC.Write(21,PinValue.Low);
            LogSys.InfoLog("motorlar calısıy");

        }
    }
}
