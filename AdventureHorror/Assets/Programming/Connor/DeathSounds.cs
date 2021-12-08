using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour
{
    public AudioSource s1;
    public AudioSource s2;
    public AudioSource s3;
    AudioClip currentSound;
    public List<SoundStruct> collisionSounds;

    public void PlayDeathSound()
    {
        int random = Random.Range(0, collisionSounds.Count - 1);
        if (collisionSounds.Count > 1)
        {
            if (collisionSounds[random].clip == currentSound)
            {
                random = Random.Range(0, collisionSounds.Count - 1);
            }
        }
        Debug.Log(collisionSounds[random]);
        currentSound = collisionSounds[random].clip;
        if (!s1.isPlaying)
        {
            s1.clip = currentSound;
            s1.time = .2f;
            s1.Play();
        }
        else if (!s2.isPlaying)
        {
            s2.clip = currentSound;
            s2.time = .2f;
            s2.Play();
        }
        else if (!s3.isPlaying)
        {
            s3.clip = currentSound;
            s3.time = .2f;
            s3.Play();
        }
    }

}
