//Brian Boersens
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        if (this.GetComponent<AudioSource>() != null)
        {
            audioSource = this.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("no sound");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!audioSource.isPlaying && collision.relativeVelocity.magnitude >= 2)
        {
            float soundVolume = collision.relativeVelocity.magnitude / 20;

            if (soundVolume > 1)
                soundVolume = 1;

            audioSource.volume = soundVolume;
            audioSource.Play();
        }
    }
}
