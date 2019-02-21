using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public SerialHandler serial;
    // Start is called before the first frame update
    void Awake()
    {
        serial = gameObject.GetComponent<SerialHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var name in serial.portName)
        {
            Debug.Log(name);
            SerialDataWrite data;
            data.baseAngle = 90;
            data.jointAngle = 90;
            data.led = Random.Range(0, 255);
            serial.WriteData(data, name);
        }
    }
}
