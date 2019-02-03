using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO.Ports;
using System.Text;


// Important! you need to change this setting:
// Edit > ProjectSettings > Player > ApiCompatibilityLevel
// Set this to .NET 4.x, (not .NET Standard 2.0)

public class BasicSerial : MonoBehaviour
{
    public string portName = "";
    public int baudRate = 9600;
    protected SerialPort serial;
    protected StringBuilder stringBuilder = new StringBuilder();

    // Start is called before the first frame update
    void Start()
    {
        serial = new SerialPort(portName, baudRate);
        serial.ReadTimeout = 1000;
        serial.WriteTimeout = 1000;
        serial.Open();
    }

    void OnDestroy() {
        if (serial.IsOpen)
        {
            serial.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!serial.IsOpen)
        {
            return;
        }

        string serialData = serial.ReadExisting();

        foreach (char c in serialData)
        {
            stringBuilder.Append(c);
            if (c == '\n')
            {
                // 01-send-potentiometer
                string data = stringBuilder.ToString();
                stringBuilder.Remove(0, stringBuilder.Length);
                Debug.Log(data);

                // 02-send-potentiometer-button
                string[] values = data.Split(',');
                foreach (string value in values)
                {
                    float.Parse(value);
                    Debug.Log(value);
                }
            }
        }
    }
}
