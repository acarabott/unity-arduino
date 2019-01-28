using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWatcher : MonoBehaviour
{
    public bool isLedOn = false;
    public float ledBrightness = 1.0f;
    public int servoAngle = 0;
    public int baseAngle = 0;
    public int jointAngle = 0;
    public GameObject watchedObject;

    protected SerialHandler serial;

    void Awake()
    {
        serial = gameObject.GetComponent<SerialHandler>();
        if (serial == null)
        {
            Debug.LogError("No SerialHandler script on this object");
        }
    }

    void Update()
    {
        if (serial == null) { return; }

        // 01-led
        // SerialDataWrite data;
        // data.isLedOn = isLedOn;
        // data.ledBrightness = Mathf.Clamp01(ledBrightness);
        // serial.WriteData(data);

        // 02-servo
        // SerialDataWrite data;
        // data.servoAngle = servoAngle;
        // serial.WriteData(data);

        // 03-robot arm
        SerialDataWrite data;
        data.baseAngle = baseAngle;
        data.jointAngle = jointAngle;
        data.isLedOn = isLedOn;
        data.ledBrightness = ledBrightness;
        data.servoAngle = servoAngle;
        serial.WriteData(data);
    }
}
