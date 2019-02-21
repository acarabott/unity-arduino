using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioAnalyser))]
public class SphereBoogie : MonoBehaviour
{
    public AudioAnalyser audioAnalyser;
    public float scaleFactor = 1f;

    public float smoothing = 0.5f;
    protected float previousScale;

    // Update is called once per frame
    void Update()
    {
        smoothing = Mathf.Max(0f, Mathf.Min(smoothing, 1f));
        float targetScale = audioAnalyser.rms * scaleFactor;
        float scale = (targetScale * smoothing) + (previousScale * (1f - smoothing));
        
        gameObject.transform.localScale = new Vector3(scale, scale, scale);

        previousScale = scale;
    }
}
