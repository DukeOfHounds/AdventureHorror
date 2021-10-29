using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : MonoBehaviour, PickUpObject
{
    private Animator screwAnimator;
    private Animator screwDriverAnimator;

    // Start is called before the first frame update
    void Start()
    {
        screwDriverAnimator = gameObject.GetComponent<Animator>();// gets screwdriver animations
    }

    /// <summary>
    /// Unscrews the screw you are currently looking at and interacting with. 
    /// </summary>
    /// <param name="screw"></param>
    public void Use(GameObject screw)
    {
        //if (screw.name.Contains("Screw"))
        if(screw.GetComponent<ManipulableObject>().manipulable ==ManipulableObject.Manipulable.screw)
        {
            screwAnimator = screw.GetComponent<Animator>();// gets screw animations
                                                           // unsrew somehow idk yet
            Debug.Log("screw begone");
            screw.SetActive(false);
        }
        
    }
}
