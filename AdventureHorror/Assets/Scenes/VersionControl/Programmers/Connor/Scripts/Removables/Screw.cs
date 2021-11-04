using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : RemovableObjects
{
    private Animator screwAnimator;

    public void Awake()
    {
        //screwAnimator = gameObject.GetComponent<Animator>();
    }

    public void Start()
    {
        removable = Removable.Screw;
        if (GetComponentInParent<Panel>().isA() == RemovableObjects.Removable.Panel)
        {
            GetComponentInParent<Panel>().AddScrewToList(this);
        }
    }
    public override void Remove()
    {
        Debug.Log("Screw Begone");
        //animation of screw being turned. 
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    // maybe IEnumerator() to have this take longer to remove screw and to have steps
}
