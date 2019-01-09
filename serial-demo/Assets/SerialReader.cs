using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Text;
using UnityEngine;

// Important! you need to change this setting:
// Edit > ProjectSettings > Player > ApiCompatibilityLevel
// Set this to .NET 2.0, (not .NET 2.0 Subset)
using System.IO.Ports;


public class SerialReader<T> {
    public List<string> portNames = new List<string> ();
    public string portName = "";
    public int baudRate = 9600;
    public int readTimeoutMs = 100;
    public T data;

    protected bool isConnected = false;
    protected bool isConnecting = false;
    protected System.Timers.Timer connectionTimer;
    protected double connectionTimeoutMs = 2000.0;
    protected bool isRunning = false;
    protected SerialPort serial;
    protected System.Threading.Timer readTimer;
    StringBuilder stringBuilder = new StringBuilder();

    public bool IsConnected
    {
        get { return isConnected; }
        set { isConnected = value; }
    }

    public void Start() {
        var platform = System.Environment.OSVersion.Platform;

        if (platform == System.PlatformID.MacOSX || platform == System.PlatformID.Unix)
        {
            string[] ttys = System.IO.Directory.GetFiles ("/dev/", "tty.*");
            foreach (string dev in ttys) {
                portNames.Add(dev);

                // Set default device
                if (dev.StartsWith("/dev/tty.usb"))
                {
                    portName = dev;
                    Debug.Log("default: " + portName);
                }
            }
        }
        else {
            foreach (var port in SerialPort.GetPortNames())
            {
                portNames.Add(port);
                // TODO windows default device
            }
        }

        Connect();
        isRunning = true;
    }

    protected void Connect() {
        isConnecting = true;
        isConnected = false;

        connectionTimer = new System.Timers.Timer()
        {
            AutoReset = false,
            Interval = connectionTimeoutMs,
        };

        connectionTimer.Elapsed += (send, args) => {
            isConnecting = false;
        };

        connectionTimer.Enabled = true;

        if (portName != "")
        {
            try {
                Debug.Log("connecting to port: " + portName + " @ " + baudRate);
                serial = new SerialPort(portName, baudRate);
                serial.Open();

                // flush
                bool isFlushed = false;
                while (!isFlushed) {
                    string serialData = serial.ReadExisting();
                    if (serialData.Length == 0)
                    {
                        isFlushed = true;
                    }
                    else {
                        foreach (char c in serialData)
                        {
                            if (c == '\n') {
                                isFlushed = true;
                            }
                        }
                    }
                }

                if (readTimer != null)
                {
                    readTimer.Dispose();
                }

                var autoEvent = new AutoResetEvent(false);
                readTimer = new System.Threading.Timer(
                    new TimerCallback(ReadFromSerial),
                    autoEvent,
                    0, // initial wait (ms)
                    16 // interval (ms)
                );

                IsConnected = true;
                Debug.Log("connected");
            }
            catch {
                IsConnected = false;
                Debug.LogError("failed to connect to serial port " + portName);
            }
        }
    }

    protected void ReadFromSerial (object state) {
        string serialData = serial.ReadExisting();
        foreach (char c in serialData)
        {
            stringBuilder.Append(c);

            if (c == '\n')
            {
                string jsonString = stringBuilder.ToString();
                stringBuilder.Remove(0, stringBuilder.Length);

                try
                {
                    data = JsonUtility.FromJson<T>(jsonString);
                }
                catch
                {
                    Debug.LogError(jsonString);
                }
            }
        }
    }

    public void Close() {
        if (readTimer != null)
        {
            readTimer.Dispose();
        }

        if (serial != null & serial.IsOpen)
        {
            serial.Close();
        }
    }
}
