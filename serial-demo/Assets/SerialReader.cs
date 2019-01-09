using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
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
    protected Thread thread;

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
        thread = new Thread(new ThreadStart(ThreadProcess));
        thread.Start();
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
                serial.ReadLine(); // flush

                IsConnected = true;
                Debug.Log("connected");
            }
            catch {
                IsConnected = false;
                Debug.LogError("failed to connect to serial port " + portName);
            }
        }
    }

    protected void ThreadProcess () {
        while (isRunning)
        {
            // If we are connected then read the data
            if (IsConnected) {
                try {
                    string jsonString = serial.ReadLine();
                    try
                    {
                        data = JsonUtility.FromJson<T>(jsonString);
                    }
                    catch
                    {
                        Debug.LogError(jsonString);
                    }
                }
                catch {
                    Debug.LogError("No data from Serial");
                }
            }
            else if (!isConnecting)
            {
                Debug.Log("connect attempt");
                Connect();
            }
        }

    }

    public void Close() {
        if (thread.IsAlive)
        {
            isRunning = false;
            thread.Join();
            if (serial != null && serial.IsOpen)
            {
                serial.Close();
            }
        }
    }
}
