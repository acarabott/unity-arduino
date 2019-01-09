using System.Threading;
using System.Timers;
using UnityEngine;

// Important! you need to change this setting:
// Edit > ProjectSettings > Player > ApiCompatibilityLevel
// Set this to .NET 2.0, (not .NET 2.0 Subset)
using System.IO.Ports;


public class SerialReader<T> {
    public string portName = "/dev/cu.usbmodem14101";
    public int baudRate = 9600;
    public int readTimeoutMs = 100;
    public T data;

    protected bool isConnected = false;
    protected bool isConnecting = false;
    protected System.Timers.Timer connectionTimer;
    protected double connectionTimeoutMs = 1000.0;
    protected bool isRunning = false;
    protected SerialPort serial;
    protected Thread thread;

    public bool IsConnected
    {
        get { return isConnected; }
        set { isConnected = value; }
    }

    public void Start() {

        Connect();
        thread = new Thread(new ThreadStart(ThreadProcess));
        thread.Start();
        isRunning = true;
    }

    protected void Connect() {
        isConnecting = true;
        connectionTimer = new System.Timers.Timer()
        {
            AutoReset = false,
            Interval = connectionTimeoutMs,
        };
        connectionTimer.Elapsed += (send, args) =>
        {
            Debug.Log("Connecting...");
            isConnecting = false;
        };
        connectionTimer.Enabled = true;

        try {
            Debug.Log(portName);
            Debug.Log(baudRate);
            serial = new SerialPort(portName, baudRate);

            serial.Open();
            serial.ReadLine(); // flush

            IsConnected = true;
        }
        catch {
            IsConnected = false;
        }
    }

    protected void ThreadProcess () {
        while (isRunning)
        {
            // If we are connected then read the data
            if (IsConnected) {
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
            else if (!isConnecting)
            {
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
