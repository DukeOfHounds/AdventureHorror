using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : RemovableObjects
{
    private Animator screwAnimator;
    private Panel panel;
    AudioSource sound;
    private bool removed;
    private string neededTool = "ScrewDriver";
    public override string NeededTool()
    {
        return neededTool;
    }
    public void Awake()
    {
        sound = GetComponent<AudioSource>();
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
        if (!removed)
        {
            sound.Play();
            StartCoroutine(Unscrew());
            removed = true;
        }
    }

    IEnumerator Unscrew()
    {
        yield return new WaitForSeconds(.5f);
        panel.RemoveScrewFromList(this);
        //animation of screw being turned. 
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.gameObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 800);
    }

}
