using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 

{

    public string name;

    public AudioClip clip;

    [Range(0,1)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
   
    //[Range(-1, 3)]
    //public float speed;

 [HideInInspector]
    public AudioSource source;
   
}
