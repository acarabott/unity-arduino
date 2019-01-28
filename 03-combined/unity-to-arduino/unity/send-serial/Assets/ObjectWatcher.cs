using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWatcher : MonoBehaviour
{
    public bool isLedOn = false;
    public float ledBrightness = 1.0f;
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

        SerialDataWrite data;
        data.isLedOn = isLedOn;
        data.ledBrightness = Mathf.Clamp01(ledBrightness);
        serial.WriteData(data);




        // if (watchedObject == null) { return; }

        // SerialDataWrite data;
        // data.x = watchedObject.transform.position.x;
        // data.y = watchedObject.transform.position.y;
        // serial.WriteData(data);
    }
}
