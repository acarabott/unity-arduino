using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalArmControl : MonoBehaviour
{
    public SerialHandler serial;
    public DigitalArmControl digitalArmControl;

    // Update is called once per frame
    void Update()
    {
        // SerialDataWrite data;
        // data.baseAngle = (int)digitalArmControl.baseServoAngle;
        // data.jointAngle = (int)digitalArmControl.jointServoAngle;

        // serial.WriteData(data);
    }
}
