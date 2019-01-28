using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWatcher : MonoBehaviour
{
    public GameObject watchedObject;

    protected SerialHandler serial;

    protected float lastMessagetime = 0.0f;

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
        if (watchedObject == null) { return; }

        SerialDataWrite data;
        data.x = watchedObject.transform.position.x;
        data.y = watchedObject.transform.position.y;
        serial.WriteData(data);
        lastMessagetime = Time.time;
    }
}
