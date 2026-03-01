using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    [SerializeField]  AudioMixer audioMixer;
     
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        Mathf.Clamp(volume * 10, 0, 20);
        int volumeToInt = (int)volume;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        Mathf.Clamp(volume * 10, 0, 20);
        int volumeToInt = (int)volume;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);

    }
    public void SetAmbianceVolume(float volume)
    {
        Mathf.Clamp(volume * 10, 0, 20);
        int volumeToInt = (int)volume;
        audioMixer.SetFloat("Ambiance", Mathf.Log10(volume) * 20);

    }

}
