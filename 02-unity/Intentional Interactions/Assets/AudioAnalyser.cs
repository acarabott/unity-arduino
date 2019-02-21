using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyser : MonoBehaviour
{
    public string inputDevice = null;
    public float sensitivity = 1f;
    public float rms;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(inputDevice, true, 1, AudioSettings.outputSampleRate);
        audioSource.loop = true;

        //wait until the microphone position is synced
        while (!(Microphone.GetPosition(inputDevice) > 0))

        audioSource.Play();
    }
    
    void Update()
    {
        int windowSize = 1024;

        float[] outputData = new float[windowSize];
        int channel = 0;
        audioSource.GetOutputData(outputData, channel);

        float sum = 0f;
        foreach (float sample in outputData)
        {
            float sensitiveSample = sample * sensitivity;
            sum += sensitiveSample * sensitiveSample;
        }
        float mean = sum / windowSize;
        rms = Mathf.Sqrt(mean);
    }
}
