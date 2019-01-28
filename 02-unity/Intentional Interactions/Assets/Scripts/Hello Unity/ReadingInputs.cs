using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingInputs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) == true)
        {
            Debug.Log("The A key has been pressed");
        }
    }
}
