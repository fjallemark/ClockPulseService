﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Ports;

namespace Tellurian.Trains.ClockPulseApp.Service.Tests;

[TestClass]
public class SerialPortSinkTests
{
    const string portName = "COM3";
    const int pauseMilliseconds = 1000;


    [TestMethod]
    public async Task SetDtr()
    {
        if (IsSerialPortAvailable(portName))
        {
            using var target = new SerialPort(portName)
            {
                Handshake = Handshake.RequestToSend,
                DtrEnable = true,
            };
            await Task.Delay(pauseMilliseconds);
            target.DtrEnable = false;
            await Task.Delay(pauseMilliseconds);
        }
        else
        {
            Assert.Inconclusive("Serial port not available");
        }
    }

    [TestMethod]
    public async Task SetRts()
    {
        if (IsSerialPortAvailable(portName))
        {

            using var target = new SerialPort(portName)
            {
                Handshake = Handshake.RequestToSend,
                RtsEnable = true
            };
            await Task.Delay(pauseMilliseconds);
            target.RtsEnable = false;
            await Task.Delay(pauseMilliseconds);
        }
        else
        {
            Assert.Inconclusive("Serial port not available");
        }
    }

    static bool IsSerialPortAvailable(string portName) => SerialPort.GetPortNames().Contains(portName);
}
