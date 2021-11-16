using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : RemovableObjects
{
    private List<Screw> screws = new List<Screw>();
    private Animator panelAnimator;
    public VentPortal VentPortal;
    public string neededTool = "none";

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
            if (VentPortal != null)
                VentPortal.canExit = true;
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

    public override string NeededTool()
    {
        return neededTool;
    }
}
