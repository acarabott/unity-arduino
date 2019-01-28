using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject rotatingObject;
    public GameObject lookatTarget;

    void Start()
    {
        
    }


    void Update()
    {
        rotatingObject.transform.LookAt(lookatTarget.transform.position);
    }
}
