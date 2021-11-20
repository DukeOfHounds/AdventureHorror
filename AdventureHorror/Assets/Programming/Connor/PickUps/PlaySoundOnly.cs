using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnly : MonoBehaviour
{
    //public SoundData sD;
    public AudioClip[] collisionSounds;
    AudioSource source;
    AudioClip currentSound;
    bool clipPlaying;
    int index;

    void Start()
    {
        
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        int random = Random.Range(0, collisionSounds.Length - 1);
        if(collisionSounds.Length > 1)
        {
            if(collisionSounds[random] = currentSound)
            {
                random = Random.Range(0, collisionSounds.Length - 1);
            }
        }
        Debug.Log(collisionSounds[random]);
        currentSound = collisionSounds[random];
        if (!source.isPlaying)
        {
            source.clip = currentSound;
            source.time = .2f;
            source.Play();
        }
        else
        {
            source.clip = currentSound;
            AudioSource temp = source;
            temp.Play();
        }
    }
}
