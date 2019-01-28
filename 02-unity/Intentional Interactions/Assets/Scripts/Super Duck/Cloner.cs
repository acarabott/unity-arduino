using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour
{

    public GameObject objectToClone;
    int cloneIndex = 1;

void Start()
{
    while(cloneIndex < 10)
    {
        Instantiate(objectToClone, new Vector3(cloneIndex * 4f, 0, 0), Quaternion.identity);
        cloneIndex = cloneIndex + 1;
    }
}


    void Update()
    {
        
    }
}
