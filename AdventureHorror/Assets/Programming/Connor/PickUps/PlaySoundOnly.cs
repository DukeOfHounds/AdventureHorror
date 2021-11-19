using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnly : MonoBehaviour
{
    AudioSource clip;
    bool clipPlaying; 

    void Start()
    {
        clip = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!clip.isPlaying)
        {
            clip.time = .2f;
            clip.Play();
        }
        else
        {
            AudioSource temp = clip;
            temp.Play();
        }
    }
}
