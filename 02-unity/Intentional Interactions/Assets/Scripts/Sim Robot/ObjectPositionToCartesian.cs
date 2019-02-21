using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionToCartesian : MonoBehaviour
{
    private CartesianControl myCartesianControl;
    public GameObject gameObjectToFollow;

    void Awake()
    {
        myCartesianControl = transform.GetComponent<CartesianControl>();
        if (myCartesianControl == null) Debug.Log("The CartesianControl script has not been wired up properly (probably not found)");





}

    void Start()
    {
        gameObjectToFollow = GameObject.Find("Target");

    }


    void Update()
    {
        if (gameObjectToFollow == null)
        {
            Debug.Log("There is nothing to follow in 'Game Object To Follow'");
            return;
        }

        myCartesianControl.xPos = -gameObjectToFollow.transform.position.x;
        myCartesianControl.yPos = gameObjectToFollow.transform.position.y;
    }
}
