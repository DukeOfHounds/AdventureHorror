using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : RemovableObjects
{
    private List<Screw> screws = new List<Screw>();
    private Animator panelAnimator;

    public void Awake()
    {
        //panelAnimator = gameObject.GetComponent<Animator>();
        removable = Removable.Panel;
    }
    public override void Remove()
    {

        if (screws.Count == 0)
        {
            Debug.Log("remove panel");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

        }

    } 
    public void AddScrewToList(Screw screw)
    {
        screws.Add(screw);
        Debug.Log("adding screw");
    }
    public void RemoveScrewFromList(Screw screw)
    {
        screws.Remove(screw);

    }
}
