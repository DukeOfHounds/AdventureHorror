using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : RemovableObjects
{
    private Animator wireAnimator;
    public Door door;
    public int color;
    private MeshRenderer material;


    public void Awake()
    {
        material = gameObject.GetComponent<MeshRenderer>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<Collider>();
        //removable = Removable.Wire;
        //wireAnimator = gameObject.GetComponent<Animator>();
    }
    public void Start()
    {
        door.AddWire(this);
        color = door.poster.NextWireColor();
        switch (color)// Red = 1, Blue = 2, Green = 3, Yellow = 4
        {
            case 1:
                material.material.color = Color.red;
                break;
            case 2:
                material.material.color = Color.blue;
                break;
            case 3:
                material.material.color = Color.green;
                break;
            case 4:
                material.material.color = Color.yellow;
                break;
            default:
                Debug.LogError("No more free colors");
                break;
        }
    }
    public override void Remove()
    {
        Debug.Log(color);
        door.RemoveWire(this);
        meshRenderer.enabled = false;
        collider.enabled = false;
    }
    
}
