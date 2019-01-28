using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresControl : MonoBehaviour
{

    public CartesianControl myCartesianControl;

    public float speed = 6f;
    public float radius = 6f;
    public float xOffset = 10f;
    public float zOffset = 10f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (radius > 8f) radius = 0f;

        radius = radius + Time.deltaTime * 0.2f;



        myCartesianControl.xPos = Mathf.Sin(Time.time * speed) * radius + xOffset;
        myCartesianControl.zPos = Mathf.Cos(Time.time * speed) * radius + zOffset;

    }
}
