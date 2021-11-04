using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : RemovableObjects
{
    private Animator wireAnimator;
    public Door door;

    public void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<Collider>();
        //removable = Removable.Wire;
        //wireAnimator = gameObject.GetComponent<Animator>();
    }
    public void Start()
    {
        door.AddWire(this);
    }
    public override void Remove()
    {
        door.RemoveWire(this);
        meshRenderer.enabled = false;
        collider.enabled = false;
    }

}
