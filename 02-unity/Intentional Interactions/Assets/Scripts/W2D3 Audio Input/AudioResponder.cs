using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioResponder : MonoBehaviour
{
    public AudioAnalyserOld audioAnalyser;
    public float scale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioAnalyser == null)
        {
            Debug.LogError("no AudioAnalyser attached");
            return;
        }

        float newScale = audioAnalyser.rootMeanSquared * scale;
        gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
