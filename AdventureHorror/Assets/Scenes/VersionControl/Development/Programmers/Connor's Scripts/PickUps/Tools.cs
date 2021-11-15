using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tools :MonoBehaviour 
{
    /// <summary>
    /// uses object in hand to interact with environment. 
    /// </summary>
    /// <param name="obj"></param>
    public abstract void Use(GameObject obj);
    public abstract string IsTool();
    
}
