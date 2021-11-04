using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpObject :MonoBehaviour 
{
    /// <summary>
    /// uses object in hand to interact with environment. 
    /// </summary>
    /// <param name="obj"></param>
    public abstract void Use(GameObject obj);
    public PickUp manipulable;   
    public enum PickUp
    {
        WireCutter,
        ScrewDriver


    }
    public PickUp isA()
    {
        return manipulable;
    }
}
