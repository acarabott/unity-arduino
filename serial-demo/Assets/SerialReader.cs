using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Important! you need to change this setting:
// Edit > ProjectSettings > Player > ApiCompatibilityLevel
// Set this to .NET 2.0, (not .NET 2.0 Subset)
using System.IO.Ports;

[System.Serializable]
public class SerialData
{
    public float potValue;
    public bool isButtonDown;
}

public class SerialReader : MonoBehaviour {
    public string portName = "/dev/cu.usbmodem145141";
    public int baudRate = 9600;
    public SerialData data = new SerialData();
    protected SerialPort serial;

    private void Start() {
        serial = new SerialPort(portName, baudRate);
    }

    void Update () {
        // If we are connected then read the data
        if (serial.IsOpen) {
            string jsonString = serial.ReadLine();
            data = JsonUtility.FromJson<SerialData>(jsonString);
        }
        else {
            // if not connected, then connect
            try {
                serial = new SerialPort(portName, baudRate);
                serial.Open();
            }
            catch {
                Debug.LogError("Could not connect to serial port " + portName);
            }
        }
    }

    void OnDestroy() {
        serial.Close();
    }
}
