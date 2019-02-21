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

    public bool autoMotion;


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
            if (autoMotion) wideCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            if (autoMotion) wideCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed) * circleRadius + circleCenterOnY;
            wideCircle[i].GetComponent<DigitalArmControl>().ledIntensity = wideLedIntensity;
        }

        for (int i = 0; i < midCircle.Length; i++)
        {
            if (autoMotion) midCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            if (autoMotion) midCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed * 2f) * circleRadius + circleCenterOnY;
            midCircle[i].GetComponent<DigitalArmControl>().ledIntensity = midLedIntensity;
        }

        for (int i = 0; i < narrowCircle.Length; i++)
        {
            if (autoMotion) narrowCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            if (autoMotion) narrowCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed *3f) * circleRadius + circleCenterOnY;
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

        if(Input.GetKey(KeyCode.I))
        {
            wideCircle[Random.Range(0,wideCircle.Length)].GetComponent<DigitalArmControl>().ledIntensity = 255;
        }

        if (Input.GetKey(KeyCode.O))
        {
            midCircle[Random.Range(0, midCircle.Length)].GetComponent<DigitalArmControl>().ledIntensity = 255;
        }

        if (Input.GetKey(KeyCode.P))
        {
            narrowCircle[Random.Range(0, narrowCircle.Length)].GetComponent<DigitalArmControl>().ledIntensity = 255;
        }



        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = speed + 0.01f;
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed = speed - 0.01f;
        }


        wideLedIntensity = Mathf.Lerp(wideLedIntensity, wideLedIntensityTarget, Time.deltaTime * 3f);
        midLedIntensity = Mathf.Lerp(midLedIntensity, midLedIntensityTarget, Time.deltaTime * 3f);
        narrowLedIntensity = Mathf.Lerp(narrowLedIntensity, narrowLedIntensityTarget, Time.deltaTime * 3f);

    }

}
