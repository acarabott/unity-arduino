using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartesianControl : MonoBehaviour
{

    private DigitalArmControl myDigitalArmControl;

    public float xPos = 5f;
    public float yPos = 5f;
    public float armLength = 10f;


    void Awake()
    {
        // Wire up the DigitalArmControl script with this one
        myDigitalArmControl = gameObject.GetComponent<DigitalArmControl>();

        // If it cannot be found print a warning in the console
        if (myDigitalArmControl == null) {Debug.Log("There is no DigitalArmControl script to control!");}
    }

    void Update()
    {
        // If myDigitalArmControl has not been wired up on Awake exit
        if (myDigitalArmControl == null){return;}

        // Make sure X never goes under 0 and Y under 1 (arm design constraints)
        if (xPos < 0.1f) xPos = 0.1f;
        if (yPos < 1) yPos = 1;

        // Converts cartesian coordinates into servo Angles using a dedicated library
        ArmAngles myArmAngles = RobotArm.CartesianToServo(xPos, yPos, armLength);

        // Write servo angles in myDigitalArmControl script
        myDigitalArmControl.baseServoAngle = myArmAngles.baseAngle;
        myDigitalArmControl.jointServoAngle = myArmAngles.jointAngle;
    }
}
