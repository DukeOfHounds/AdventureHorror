using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : RemovableObjects
{
    private List<Screw> screws = new List<Screw>();
    private Animator panelAnimator;

    public void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<Collider>();
        //panelAnimator = gameObject.GetComponent<Animator>();
        //removable = Removable.Panel;
    }
    public override void Remove()
    {
        if (screws.Count == 0)
        {
            meshRenderer.enabled = false;
            collider.enabled = false;
        }
    } 
    public void AddScrewToList(Screw screw)
    {
        screws.Add(screw);
    }
    public void RemoveScrewFromList(Screw screw)
    {
        screws.Remove(screw);

    }
}
