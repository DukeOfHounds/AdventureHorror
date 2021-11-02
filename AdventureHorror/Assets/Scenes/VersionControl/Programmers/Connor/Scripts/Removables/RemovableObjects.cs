using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RemovableObjects : MonoBehaviour
{
    public abstract void Remove();
    public Removable removable;

    public enum Removable
    {
       Panel,
        Wire,
        Screw
    }
    public Removable isA()
    {
        return removable;
    }
}
