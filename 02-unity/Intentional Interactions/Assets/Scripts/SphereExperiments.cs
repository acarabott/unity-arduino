using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Module Notes: 

public class SphereExperiments : MonoBehaviour
{
    // Object that we will be modifying
    public GameObject targetSphere;

    // Public float variable to control the Sphere movements
    public float translationSpeed = 0.1f;  

    // Start is called before the first frame update
    void Start()
    {
        // Change the color of  targetSphere's MeshRenderer to standard blue
        targetSphere.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        float spherePosX = targetSphere.transform.position.x;
        float spherePosY = Mathf.Sin(Time.time);
        float spherePosZ = targetSphere.transform.position.z;

        targetSphere.transform.position = new Vector3(spherePosX, spherePosY, spherePosZ);

        // If user presses Q
        if (Input.GetKey(KeyCode.Q))
        {
            // Change the color of targetSphere's MeshRenderer to standard green
            targetSphere.GetComponent<MeshRenderer>().material.color = Color.green;

            // Move targetSphere on X by small increments
            targetSphere.transform.Translate(translationSpeed, 0, 0);
        }

        // If user presses W
        if (Input.GetKey(KeyCode.W))
        {
            // Change the color of targetSphere's MeshRenderer to standard red
            targetSphere.GetComponent<MeshRenderer>().material.color = Color.red;

            // Move targetSphere on X by small increments
            targetSphere.transform.Translate(-translationSpeed, 0, 0);
        }

        //
        //float sphereYPos = Mathf.Sin(Time.time);




    }

}