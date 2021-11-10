using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : RemovableObjects
{
    private Animator screwAnimator;
    private Panel panel;

    public void Awake()
    {
        panel = GetComponentInParent<Panel>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<Collider>();
        //screwAnimator = gameObject.GetComponent<Animator>();
    }

    public void Start()
    {
        //removable = Removable.Screw;
        panel.AddScrewToList(this);

    }
    public override void Remove()
    {
        panel.RemoveScrewFromList(this);
        //animation of screw being turned. 
        meshRenderer.enabled = false;
        collider.enabled = false;
    }

    // maybe IEnumerator() to have this take longer to remove screw and to have steps
}
