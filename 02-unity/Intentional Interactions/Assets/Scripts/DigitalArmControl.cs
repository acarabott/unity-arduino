using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalArmControl : MonoBehaviour
{
    public GameObject baseServoGameObject;
    public GameObject jointServoGameObject;

    public float baseServoAngle = 0f;
    public float jointServoAngle = 0f;

    public float cruiseServoSpeed = 6f;

    private float baseServoSpeed = 1f;
    private float jointServoSpeed = 1f;
    private float highSpeedFactor = 3f; 

    private float dynamicBaseServoAngle = 0f;
    private float dynamicJointServoAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (baseServoAngle - dynamicBaseServoAngle < 30) baseServoSpeed = cruiseServoSpeed * highSpeedFactor;
         else*/
        baseServoSpeed = cruiseServoSpeed;

        /*if (jointServoAngle - dynamicBaseServoAngle < 30) jointServoSpeed = cruiseServoSpeed * highSpeedFactor;
        else*/
        jointServoSpeed = cruiseServoSpeed;


        // Linear interpolation that makes the real angle get closer to the targeted angle at each frame
        dynamicBaseServoAngle = Mathf.Lerp(dynamicBaseServoAngle, baseServoAngle, Time.deltaTime * baseServoSpeed);
        dynamicJointServoAngle = Mathf.Lerp(dynamicJointServoAngle, jointServoAngle, Time.deltaTime * jointServoSpeed);

        // Zeroing the rotation of each servo GameObject
        baseServoGameObject.transform.rotation = Quaternion.identity;
        jointServoGameObject.transform.rotation = Quaternion.identity;

        // Apply rotation in degrees from baseServoAngle and jointServoAngle
        baseServoGameObject.transform.Rotate(0, 0, -dynamicBaseServoAngle);
        jointServoGameObject.transform.Rotate(0, 0, -dynamicJointServoAngle);
    }
}
