using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCutter : Tool
{
    private Animator wireAnimator;
    private Animator wireCutterAnimator;
    private string isTool = "WireCutter";

    //private Screw S;

    // Start is called before the first frame update
    void Start()
    {
        wireCutterAnimator = gameObject.GetComponent<Animator>();// gets screwdriver animations
    }

    /// <summary>
    /// Cuts the wire you are currently looking at and interacting with. 
    /// </summary>
    /// <param name="wire"></param>
    public override void Use(GameObject wire)
    {
        
            //wireAnimator = wire.GetComponent<Animator>();// gets wire animations
            Debug.Log("Wire begone");
            wire.GetComponent<Wire>().Remove();
        

    }

    public override string IsTool()
    {
        return isTool;
    }
}
