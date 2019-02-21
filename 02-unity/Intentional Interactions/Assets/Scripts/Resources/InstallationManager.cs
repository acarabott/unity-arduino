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
            wideCircle[i].GetComponent<DigitalArmControl>().ledIntensity = Mathf.Abs(Mathf.Sin(Time.time * ledSpeed)) * 255f;
        }

        for (int i = 0; i < midCircle.Length; i++)
        {
            midCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            midCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed * 2f) * circleRadius + circleCenterOnY;
            midCircle[i].GetComponent<DigitalArmControl>().ledIntensity = Mathf.Abs(Mathf.Sin(Time.time * ledSpeed *2f)) * 255f;
        }

        for (int i = 0; i < narrowCircle.Length; i++)
        {
            narrowCircle[i].GetComponent<CartesianControl>().xPos = Mathf.Cos(Time.time * speed) * circleRadius + circleCenterOnX;
            narrowCircle[i].GetComponent<CartesianControl>().yPos = Mathf.Sin(Time.time * speed *3f) * circleRadius + circleCenterOnY;
            narrowCircle[i].GetComponent<DigitalArmControl>().ledIntensity = Mathf.Abs(Mathf.Sin(Time.time * ledSpeed*0.5f)) * 255f;
        }






    }
}
