using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallationManager : MonoBehaviour
{

    public GameObject[] wideCircle;
    public GameObject[] midCircle;
    public GameObject[] narrowCircle;

    public float circleCenterOnX = 8;
    public float circleCenterOnY = 8;

    public float circleRadius = 5;

    public float speed = 1f;
    public float ledSpeed = 1f;

    public float wideLedIntensityTarget;
    public float midLedIntensityTarget;
    public float narrowLedIntensityTarget;

    public float wideLedIntensity;
    public float midLedIntensity;
    public float narrowLedIntensity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sin wave on each circle

        for(int i = 0; i < wideCircle.Length;i++)
        {
            wideCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            wideCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed) * circleRadius + circleCenterOnY;
            wideCircle[i].GetComponent<DigitalArmControl>().ledIntensity = wideLedIntensity;
        }

        for (int i = 0; i < midCircle.Length; i++)
        {
            midCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            midCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed * 2f) * circleRadius + circleCenterOnY;
            midCircle[i].GetComponent<DigitalArmControl>().ledIntensity = midLedIntensity;
        }

        for (int i = 0; i < narrowCircle.Length; i++)
        {
            narrowCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            narrowCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed *3f) * circleRadius + circleCenterOnY;
            narrowCircle[i].GetComponent<DigitalArmControl>().ledIntensity = narrowLedIntensity;
        }


        if(Input.GetKey(KeyCode.Q))
        {
            wideLedIntensity = 255;
            wideLedIntensityTarget = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            midLedIntensity = 255;
            midLedIntensityTarget = 0f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            narrowLedIntensity = 255;
            narrowLedIntensityTarget = 0f;
        }


        wideLedIntensity = Mathf.Lerp(wideLedIntensity, wideLedIntensityTarget, Time.deltaTime * 3f);
        midLedIntensity = Mathf.Lerp(midLedIntensity, midLedIntensityTarget, Time.deltaTime * 3f);
        narrowLedIntensity = Mathf.Lerp(narrowLedIntensity, narrowLedIntensityTarget, Time.deltaTime * 3f);


    }





    IEnumerator wideLedFade()
    {
        wideLedIntensity = 255f;
        wideLedIntensityTarget = 255f;
        yield return new WaitForSeconds(1f);
        wideLedIntensityTarget = 0f;
        yield return null;
    }

}
