using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameJr : PickUpBehavior
{
    public AudioSource audio;
    public override void PlayPickUp()
    {
        audio.Play();
    }
}
