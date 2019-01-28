using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServoControl : MonoBehaviour
{
    public ArmAngles myArmAngles;

    //public float baseServoAngle = 0f;
    //public float jointServoAngle = 0f;

    public float xPos = 0f;
    public float zPos = 0f;

    public float radius = 6f;
    public float xOffset = 10f;
    public float zOffset = 10f;




    public GameObject baseServo;
    public GameObject jointServo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //xPos = Mathf.Cos(Time.time * 3f) * radius + xOffset;
        //zPos = Mathf.Sin(Time.time * 3f) * radius + zOffset;

        myArmAngles = RobotArm.CartesianToServo(xPos, zPos, 10f);

        baseServo.transform.rotation = Quaternion.identity;
        jointServo.transform.rotation = Quaternion.identity;

        baseServo.transform.Rotate(0, 0, -myArmAngles.baseAngle);
        jointServo.transform.Rotate(0, 0, -myArmAngles.jointAngle);
    }
}
