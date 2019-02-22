using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalArmControl : MonoBehaviour
{
    public GameObject baseServoGameObject;
    public GameObject jointServoGameObject;
    public Light virtualLED;

    public float baseServoAngle = 0f;
    public float jointServoAngle = 0f;

    public float servoSpeed = 6f;

    private float dynamicBaseServoAngle = 0f;
    private float dynamicJointServoAngle = 0f;

    public float ledIntensity = 0f;

    void Update()
    {
        // Linear interpolation that makes the real angle get closer to the targeted angle at each frame
        dynamicBaseServoAngle = Mathf.Lerp(dynamicBaseServoAngle, baseServoAngle, Time.deltaTime * servoSpeed);
        dynamicJointServoAngle = Mathf.Lerp(dynamicJointServoAngle, jointServoAngle, Time.deltaTime * servoSpeed);

        // Zero the rotation of each servo GameObject
        baseServoGameObject.transform.rotation = Quaternion.identity;
        jointServoGameObject.transform.rotation = Quaternion.identity;

        // Apply rotation in degrees from baseServoAngle and jointServoAngle
        baseServoGameObject.transform.Rotate(0, 0, -dynamicBaseServoAngle);
        jointServoGameObject.transform.Rotate(0, 0, 180-dynamicJointServoAngle);


        //virtual LED
        virtualLED.intensity = ledIntensity / 100f;

    }
}
