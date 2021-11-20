using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnly : MonoBehaviour
{
    AudioSource source;
    AudioClip currentSound;
    public List<SoundStruct> collisionSounds;
    bool clipPlaying;
    int index;

    void Start()
    {
        
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        int random = Random.Range(0, collisionSounds.Count - 1);
        if(collisionSounds.Count > 1)
        {
            if(collisionSounds[random].clip == currentSound)
            {
                random = Random.Range(0, collisionSounds.Count - 1);
            }
        }
        Debug.Log(collisionSounds[random]);
        currentSound = collisionSounds[random].clip;
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
