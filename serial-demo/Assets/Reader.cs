using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SerialData
{
    public float potValue;
    public bool isButtonDown;
}

public class Reader : MonoBehaviour
{
    public SerialReader<SerialData> serialReader;

    // Start is called before the first frame update
    void Start()
    {
        serialReader = new SerialReader<SerialData>();
        serialReader.Start();
    }

    // Update is called once per frame
    void Update()
    {
        SerialData data = serialReader.data;
    }

    void OnDestroy()
    {
        serialReader.Close();
    }
}
