using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RemovableObjects : MonoBehaviour
{
    /// <summary>
    ///Removes object from scene 
    ///Later will give it an animation and possibly dorp to the floor. 
    /// </summary>
    /// <param name="obj"></param>
    public abstract void Remove();
    public abstract string NeededTool();
    //public Removable removable;
    protected MeshRenderer meshRenderer;
    protected Collider collider;
    

    //public enum Removable
    //{
    //   Panel,
    //    Wire,
    //    Screw
    //}
    //public Removable isA()
    //{
    //    return removable;
    //}
}
