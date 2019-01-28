using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresControl : MonoBehaviour
{

    public CartesianControl myCartesianControl;

    public float speed = 6f;
    public float radius = 6f;
    public float xOffset = 10f;
    public float yOffset = 10f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (radius > 8f) radius = 0f;

        //adius = radius + Time.deltaTime * 0.2f;



        myCartesianControl.xPos = Mathf.Sin(Time.time * speed) * radius + xOffset;
        myCartesianControl.yPos = Mathf.Cos(Time.time * speed) * radius + yOffset;

    }
}
