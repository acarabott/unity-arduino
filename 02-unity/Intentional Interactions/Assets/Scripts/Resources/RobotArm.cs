using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ArmAngles
{
    public float baseAngle;
    public float jointAngle;
}


public class RobotArm
{
    public static ArmAngles CartesianToServo(float x, float y, float armLength)
    {
        ArmAngles thisArmAngles;

        // Calculates the hypotenuse of the triangle formed by the two robot arms
        float distanceToTarget = Mathf.Sqrt(x * x + y * y);

        // Makes sure the hypotenuse is never higher than the addition of the length of the two robot arms
        if (distanceToTarget > 2f * armLength) distanceToTarget = 2f * armLength;

        // angle between the hypotenuse and the horizon
        float alpha = Mathf.Atan(y / Mathf.Max(x, 0.001f)) * Mathf.Rad2Deg;

        // angle between the hypotenuse and the first arm
        float beta = Mathf.Acos(distanceToTarget / (2f * armLength)) * Mathf.Rad2Deg;

        // base angle
        thisArmAngles.baseAngle = alpha + beta;

        // joint angle
        thisArmAngles.jointAngle = (180f - 2f * beta);


        return thisArmAngles;
    }



}
