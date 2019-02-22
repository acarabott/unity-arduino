using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleToCartesian : MonoBehaviour
{

    private CartesianControl myCartesianControl;

    public float circleCenterOnX;
    public float circleCenterOnY;

    public float circleRadius;

    public float speed = 1f;



    void Awake()
    {
        // Assign to myCartesianControl the component of CartesianControl type
        // that is attached the gameObject this script is attached to
        myCartesianControl = gameObject.GetComponent<CartesianControl>();

        if (myCartesianControl == null)
            Debug.Log("It seems that there is not CartesianControl script attached to this GameObject");
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Writing X and Y positions using parametric equation of a circle
        myCartesianControl.xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
        myCartesianControl.yPos = Mathf.Sin(Time.time * speed) * circleRadius + circleCenterOnY;
    }
}
