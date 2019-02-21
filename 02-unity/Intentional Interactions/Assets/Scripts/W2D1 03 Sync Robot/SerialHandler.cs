using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Text;
using Unity.Collections;
using UnityEngine;
using System.IO.Ports;

// Important! you need to change this setting:
// Edit > ProjectSettings > Player > ApiCompatibilityLevel
// Set this to .NET 4.x, (not .NET Standard 2.0)


public class SerialHandler : MonoBehaviour {
   [Header("Info")]

    public string status = "Disconnected";

    public List<string> availablePorts = new List<string> ();

    [Header("Options (must set before Play)")]
    public List<string> portName = new List<string>();
    public int baudRate = 115200;
    public double connectionTimeoutMs = 2000.0;
    public SerialDataRead data;

    protected bool isConnected = false;
    protected bool isConnecting = false;
    protected Dictionary<string, SerialPort> serial = new Dictionary<string, SerialPort>();
    protected System.Timers.Timer connectionTimer;
    protected System.Threading.Timer readTimer;
    protected StringBuilder stringBuilder = new StringBuilder();

    protected Dictionary<string, System.Threading.Timer> writeTimer = new Dictionary<string, System.Threading.Timer>();
    protected Dictionary<string, Queue<string>> writeQueue = new Dictionary<string, Queue<string>>();
    public Dictionary<string, SerialDataWrite> writeData = new Dictionary<string, SerialDataWrite>();

    void Start()
    {
        status = "Disconnected";
        Connect();
    }

    void Update()
    {
        if (!isConnected && !isConnecting)
        {
            Connect();
        }
    }

    public void OnDestroy()
    {
        if (readTimer != null)
        {
            readTimer.Dispose();
        }

        // if (serial != null & serial.IsOpen)
        // {
        //     serial.Close();
        // }
    }

    public void Write(string data)
    {
        if (!isConnected)
        {
            Debug.LogError("Serial port is not connected");
            return;
        }
        foreach (var s in serial)
        {
            s.Value.Write(data);
        }
    }

    public void WriteLine(string data, string port)
    {
        if (!isConnected)
        {
            Debug.LogError("Serial port is not connected");
            return;
        }

        writeQueue[port].Enqueue(data);
    }

    public void WriteData(SerialDataWrite data, string port)
    {
        var json = JsonUtility.ToJson(data);
        WriteLine(json, port);
        writeData[port] = data;
    }

    protected void Connect() {
        // reset state
        isConnecting = true;
        isConnected = false;
        availablePorts.Clear();
        status = "Connecting...";

        // Get list of devices, set default device
        var platform = System.Environment.OSVersion.Platform;
        var isMacOrUnix = platform == System.PlatformID.MacOSX ||
                          platform == System.PlatformID.Unix;
        var ports = isMacOrUnix
            ? System.IO.Directory.GetFiles ("/dev/", "tty.*")
            : SerialPort.GetPortNames();
        var defaultPrefix = isMacOrUnix
            ? "/dev/tty.usb"
            : "COM";

        foreach (var port in ports) {
           availablePorts.Add(port);
           if (port.StartsWith(defaultPrefix, StringComparison.Ordinal))
           {
               portName.Add(port);
               writeQueue[port] = new Queue<string>();
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

        foreach (var port in portName)
        {
            try {
                Debug.Log("connecting to port: " + portName + " @ " + baudRate);
                SerialPort sp = new SerialPort(port, baudRate);
                serial[port] = sp;
                sp.ReadTimeout = 10;
                sp.WriteTimeout = 10;
                sp.Open();
                isConnected = true;
                status = "Connected";
            }
            catch {
                isConnected = false;
                Debug.LogError("failed to connect to serial port " + portName);
            }

            if (isConnected)
            {
                status = "connected: waiting for serial data";
                if (writeTimer.ContainsKey(port))
                {
                    writeTimer[port].Dispose();
                }
                var writeEvent = new AutoResetEvent(false);
                writeTimer[port] = new System.Threading.Timer(
                    new TimerCallback((object state) => {
                        while (writeQueue[port].Count > 0)
                        {
                            string dataToWrite = writeQueue[port].Dequeue();
                            serial[port].WriteLine(dataToWrite);
                        }
                    }),
                    writeEvent,
                    3000, // initial wait (ms)
                    16 // interval (ms)
                );
            }
        }
    }
}
