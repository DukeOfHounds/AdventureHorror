using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : PickUpObject
{
    private Animator screwDriverAnimator;


    private void Awake()
    {
        //screwDriverAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        screwDriverAnimator = gameObject.GetComponent<Animator>();// gets screwdriver animations
    }

    
    public override void Use(GameObject screw)
    {

        if (screw.TryGetComponent<Screw>(out Screw screwComponent))
        {
            
            screwComponent.Remove();// unsrew somehow idk yet
        }

    }
}
