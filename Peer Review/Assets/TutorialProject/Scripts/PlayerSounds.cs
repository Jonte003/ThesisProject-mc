using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void OnMovement()
    {
        audioSource.clip = SoundBank.instance.stepClip;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }
    void OnMovementStop()
    {
        audioSource.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
