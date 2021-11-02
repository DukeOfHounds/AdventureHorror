using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : PickUpObject
{
    private Animator screwAnimator;
    private Animator screwDriverAnimator;

    //private Screw S;

    // Start is called before the first frame update
    void Start()
    {
        screwDriverAnimator = gameObject.GetComponent<Animator>();// gets screwdriver animations
        manipulable = PickUp.ScrewDriver;
    }

    /// <summary>
    /// Unscrews the screw you are currently looking at and interacting with. 
    /// </summary>
    /// <param name="screw"></param>
    public override void Use(GameObject screw)
    {
        //S = screw.GetComponent<Screw>();
        if (screw.name.Contains("Screw"))
        //if (canManipulate.Equals(S.isA))//
        {

            screwAnimator = screw.GetComponent<Animator>();// gets screw animations
                                                           // unsrew somehow idk yet

            if (screw.GetComponentInParent<Panel>().isA() == RemovableObjects.Removable.Panel)
            {
                Debug.Log("screw begone");
                screw.GetComponentInParent<Panel>().RemoveScrewFromList(screw);
                screw.GetComponent<Screw>().Remove();
            }
        }

    }
}
