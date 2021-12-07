using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedZone : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource music;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("player has entered the restricted zone");
            audio.Play();
            music.volume = (float).5;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("player has left the restricted zone");
            audio.Stop();
            music.volume = (float)1;
        }
    }
}
