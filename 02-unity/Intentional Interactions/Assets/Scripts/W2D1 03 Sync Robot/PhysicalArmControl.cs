using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalArmControl : MonoBehaviour
{
    SerialHandler serialHandler;
    protected DigitalArmControl digitalArmControl;

    // public int jointAngleOffset = -30;
    public int jointAngleOffset = 0;

    void Awake()
    {
       digitalArmControl = gameObject.GetComponent<DigitalArmControl>();
       if (digitalArmControl == null)
       {
           Debug.LogError("Component must have a DigitalArmControl component");
       }

       serialHandler = gameObject.GetComponent<SerialHandler>();
       if (serialHandler == null)
       {
          Debug.LogError("Component must have a SerialHandler component");
       }
    }

    // Update is called once per frame
    void Update()
    {
        if (digitalArmControl == null) { return; }
        if (serialHandler == null) { return; }

        SerialDataWrite data;
        data.baseAngle = (int)digitalArmControl.baseServoAngle;
        data.jointAngle = (int)digitalArmControl.jointServoAngle + jointAngleOffset;

        // temp for compatibility
        data.isLedOn = false;
        data.ledBrightness = 1.0f;
        data.servoAngle = 0;
        // end temp

        serialHandler.WriteData(data);
    }
}
