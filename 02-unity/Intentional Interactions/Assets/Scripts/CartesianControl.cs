using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartesianControl : MonoBehaviour
{

    private DigitalArmControl myDigitalArmControl;

    public float xPos = 5f;
    public float zPos = 5f;
    public float armLength = 10f;


    void Awake()
    {
        myDigitalArmControl = gameObject.GetComponent<DigitalArmControl>();
    }

    void Update()
    {
        if (xPos < 0.1f) xPos = 0.1f;
        if (zPos < 1) zPos = 1;

        // Converts cartesian coordinates into servo Angles using a dedicated library
        ArmAngles myArmAngles = RobotArm.CartesianToServo(xPos, zPos, armLength);

        // Write servo angles in myDigitalArmControl script
        myDigitalArmControl.baseServoAngle = myArmAngles.baseAngle;
        myDigitalArmControl.jointServoAngle = myArmAngles.jointAngle;


        // Print a warning in the console if myDigitalArmControl has not been wired up on Awake
        if (myDigitalArmControl == null) Debug.Log("There is no DigitalArmControl script to control!");




    }
}
