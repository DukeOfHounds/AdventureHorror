using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : RemovableObjects
{
    public void Awake()
    {
        removable = Removable.Wire;
    }
    public override void Remove()
    {
        Debug.Log("remove wire");
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }

}
