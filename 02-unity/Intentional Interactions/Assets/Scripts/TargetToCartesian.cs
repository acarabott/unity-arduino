using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetToCartesian : MonoBehaviour
{
    public CartesianControl myCartesianControl;
    public GameObject gameObjectToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        myCartesianControl.xPos = -gameObjectToFollow.transform.position.x;
        myCartesianControl.zPos = gameObjectToFollow.transform.position.y;


    }
}
