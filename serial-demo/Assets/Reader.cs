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
    public SerialData data;

    // Start is called before the first frame update
    void Start()
    {
        serialReader = new SerialReader<SerialData>();
        serialReader.Start();
    }

    // Update is called once per frame
    void Update()
    {
        serialReader.Update();
        data = serialReader.data;
    }

    void OnDestroy()
    {
        serialReader.Close();
    }
}
