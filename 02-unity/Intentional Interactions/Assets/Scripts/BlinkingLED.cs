using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLED : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<Light>().intensity = Mathf.Sin(Time.time*4f) * 1.3f + 1f;
        
    }
}
