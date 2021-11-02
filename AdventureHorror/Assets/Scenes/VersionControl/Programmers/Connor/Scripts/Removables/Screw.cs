using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : RemovableObjects
{
    public void Start()
    {
        removable = Removable.Screw;
        if (GetComponentInParent<Panel>().isA() == RemovableObjects.Removable.Panel)
        {
            GetComponentInParent<Panel>().AddScrewToList(this.gameObject);
        }
    }
    public override void Remove()
    {
        Debug.Log("Screw Begone");
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
