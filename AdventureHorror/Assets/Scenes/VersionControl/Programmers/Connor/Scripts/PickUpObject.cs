using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpObject :MonoBehaviour 
{
    public abstract void Use(GameObject obj);
    public Manipulable manipulable;
    // Start is called before the first frame update
   
    public enum Manipulable
    {
        Screw,
        ScrewDriver


    }
}
