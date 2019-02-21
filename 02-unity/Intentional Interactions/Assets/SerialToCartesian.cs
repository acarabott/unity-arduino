using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialToCartesian : MonoBehaviour
{
    private SerialHandler serial;
    private CartesianControl cartesian;

    // Start is called before the first frame update
    void Start()
    {
        serial = gameObject.GetComponent<SerialHandler>();
        cartesian = gameObject.GetComponent<CartesianControl>();

        Debug.Log("map: " + Map.LinLin(10, 5, 15, 0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        
        float sensorValue = serial.data.A0;
        cartesian.xPos = sensorValue * 8;


        //cartesian.xPos = sensorValue > 0.5 ? 6 : 2;
    }
}
