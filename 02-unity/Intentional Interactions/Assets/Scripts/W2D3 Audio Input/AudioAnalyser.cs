using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyser : MonoBehaviour
{
    public string inputDevice = null;
    public AudioMixer audioMixer;
    public float sensitivity = 1.0f;

    public float rootMeanSquared;

    protected Microphone microphone;
    protected AudioSource audioSource;
    protected readonly int windowSize = 1024;

    void Start()
    {
        // create the microphone input
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(inputDevice, true, 1, AudioSettings.outputSampleRate);
        audioSource.loop = true;

        // wait until the microphone position is synced
        while (!(Microphone.GetPosition(inputDevice) > 0)) { }

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float[] outputData = new float[windowSize];
        const int channel = 0;
        audioSource.GetOutputData(outputData, channel);

        float sum = 0f;
        foreach (float sample in outputData)
        {
            float scaled = sample * sensitivity;
            sum += scaled * scaled;
        }

        float mean = sum / windowSize;
        rootMeanSquared = Mathf.Sqrt(mean);
    }
}
