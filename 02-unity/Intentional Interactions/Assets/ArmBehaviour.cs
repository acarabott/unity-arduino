using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public SerialHandler serial;
    public InstallationManager manager;
    // Start is called before the first frame update

    public List<DigitalArmControl> controls = new List<DigitalArmControl>();
    void Awake()
    {
        serial = gameObject.GetComponent<SerialHandler>();
        manager = gameObject.GetComponent<InstallationManager>();
    }

    void Start()
    {
        foreach (var obj in manager.wideCircle)
        {
            DigitalArmControl control = obj.GetComponent<DigitalArmControl>();
            if (control != null)
            {
                controls.Add(control);
            }
        }
        foreach (var obj in manager.midCircle)
        {
            DigitalArmControl control = obj.GetComponent<DigitalArmControl>();
            if (control != null)
            {
                controls.Add(control);
            }
        }
        foreach (var obj in manager.narrowCircle)
        {
            DigitalArmControl control = obj.GetComponent<DigitalArmControl>();
            if (control != null)
            {
                controls.Add(control);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < serial.portName.Count; i++)
        {
            string name = serial.portName[i];
            if (i < controls.Count)
            {
                DigitalArmControl control = controls[i];
                SerialDataWrite data;
                data.baseAngle = (int)control.baseServoAngle;
                data.jointAngle = (int)control.jointServoAngle;
                data.led = (int)control.ledIntensity;
                serial.WriteData(data, name);
            }
        }
    }
}
