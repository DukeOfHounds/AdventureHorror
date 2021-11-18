using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : RemovableObjects
{
    private Animator screwAnimator;
    private Panel panel;
    public string neededTool = "ScrewDriver";
    public override string NeededTool()
    {
        return neededTool;
    }
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
        FindObjectOfType<AudioManager>().Play("unscrewing_2");
        StartCoroutine(Unscrew());
    }

    IEnumerator Unscrew()
    {
        yield return new WaitForSeconds(.5f);
        panel.RemoveScrewFromList(this);
        //animation of screw being turned. 
        meshRenderer.enabled = false;
        collider.enabled = false;
    }
}
