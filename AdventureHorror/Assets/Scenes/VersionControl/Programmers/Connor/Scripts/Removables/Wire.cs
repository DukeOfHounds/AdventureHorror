using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : RemovableObjects
{
    private Animator wireAnimator;
    public Door door;

    public void Awake()
    {
        removable = Removable.Wire;
        //wireAnimator = gameObject.GetComponent<Animator>();
    }
    public void Start()
    {
        door.AddWire(this);
    }
    public override void Remove()
    {
        Debug.Log("remove wire");
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }

}
