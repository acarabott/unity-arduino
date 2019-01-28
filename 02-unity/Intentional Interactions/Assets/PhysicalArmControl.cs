using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalArmControl : MonoBehaviour
{
    SerialHandler serialHandler;
    protected DigitalArmControl digitalArmControl;

    public int jointAngleOffset = -30;
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
        data.baseAngle = 180 - (int)digitalArmControl.baseServoAngle;
        data.jointAngle = (int)digitalArmControl.jointServoAngle + jointAngleOffset;
        serialHandler.WriteData(data);
    }
}
