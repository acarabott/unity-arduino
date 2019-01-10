using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Text;
using Unity.Collections;
using UnityEngine;

// Important! you need to change this setting:
// Edit > ProjectSettings > Player > ApiCompatibilityLevel
// Set this to .NET 4.x, (not .NET Standard 2.0)

using System.IO.Ports;

public class SerialReader : MonoBehaviour {
    [Header("Info")]

    public string status = "Disconnected";

    public List<string> availablePorts = new List<string> ();

    [Header("Options (must set before Play)")]
    public string portName = "";
    public int baudRate = 9600;
    public double connectionTimeoutMs = 2000.0;
    public SerialData data;

    protected bool isConnected = false;
    protected bool isConnecting = false;
    protected SerialPort serial;
    protected System.Timers.Timer connectionTimer;
    protected System.Threading.Timer readTimer;
    StringBuilder stringBuilder = new StringBuilder();

    public void Start() {
        status = "Disconnected";
        Connect();
    }

    public void Update() {
        if (!isConnected && !isConnecting)
        {
            Connect();
        }
    }

    protected void Connect() {
        // reset state
        isConnecting = true;
        isConnected = false;
        availablePorts.Clear();
        status = "Connecting...";

        // Get list of devices, set default device
        var platform = System.Environment.OSVersion.Platform;

        if (platform == System.PlatformID.MacOSX || platform == System.PlatformID.Unix)
        {
            string[] ttys = System.IO.Directory.GetFiles ("/dev/", "tty.*");
            foreach (string dev in ttys) {
                availablePorts.Add(dev);

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
                availablePorts.Add(port);
                // TODO windows default device
            }
        }

        // Create reconnect timer
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

                isConnected = true;
                status = "Connected";
            }
            catch {
                isConnected = false;
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
                    data = JsonUtility.FromJson<SerialData>(jsonString);
                }
                catch
                {
                    Debug.LogError("bad data: " + jsonString);
                }
            }
        }
    }

    public void OnDestroy() {
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
