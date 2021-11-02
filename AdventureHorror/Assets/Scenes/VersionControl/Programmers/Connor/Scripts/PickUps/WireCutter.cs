using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCutter : PickUpObject
{
    private Animator wireAnimator;
    private Animator wireCutterAnimator;

    //private Screw S;

    // Start is called before the first frame update
    void Start()
    {
        wireCutterAnimator = gameObject.GetComponent<Animator>();// gets screwdriver animations
        manipulable = PickUp.WireCutter;
    }

    /// <summary>
    /// Cuts the wire you are currently looking at and interacting with. 
    /// </summary>
    /// <param name="wire"></param>
    public override void Use(GameObject wire)
    {
        //S = screw.GetComponent<Screw>();
        if (wire.name.Contains("Wire"))
        //if (canManipulate.Equals(S.isA))//
        {
            wireAnimator = wire.GetComponent<Animator>();// gets wire animations
                                                           // cuts wire somehow idk yet
            Debug.Log("Wire begone");
            wire.SetActive(false);
        }

    }
}
