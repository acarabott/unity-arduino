using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Set this to .NET 2.0, (not .NET 2.0 Subset)
// Edit > ProjectSettings > Player > ApiCompatibilityLevel
using System.IO.Ports;

[System.Serializable]
public class SerialData
{
    public float potValue;
    public bool isButtonDown;
}


public class SerialReader : MonoBehaviour {
    public string serialPort = "/dev/cu.usbmodem145141";
    public int baudRate = 9600;
    public SerialData data;
    public bool isConnected = false;

    protected SerialPort serial;

    void Connect() {
        if (serial != null && serial.IsOpen) {
            serial.Close();
        }

        serial = new SerialPort(serialPort, baudRate);

        try {
            serial.Open();
        }
        catch {
            Debug.LogError("Could not connect to serial port " + serialPort);
        }

        isConnected = true;
    }

    void Start () {
        Connect();
    }
    
    // Update is called once per frame
    void Update () {
        if (serial == null) { Connect(); }

        if (serial.IsOpen) {
            string jsonString = serial.ReadLine();
            data = JsonUtility.FromJson<SerialData>(jsonString);
        }
        else {
            isConnected = false;
            Connect();
        }
    }

    void OnDestroy() {
        serial.Close();
        isConnected = false;
    }
}
