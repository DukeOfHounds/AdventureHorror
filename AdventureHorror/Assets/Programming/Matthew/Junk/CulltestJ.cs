using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culltest : MonoBehaviour
{
    //lookTarget is the player or look target
    private GameObject lookTarget;
    //Chuck is the parent of all object in a group to be culled
    public GameObject Chuck;
    // CHuck is called before the first frame update
    public float Chucks_radius;
    void Awake()
    {
        //you already know what this does asshole
        lookTarget = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //Set Chuck active, in turn setting all of the children active, based on distance to player/lookTarget
        Chuck.SetActive(Vector3.Distance(lookTarget.transform.position, Chuck.transform.position) < Chucks_radius);
    }
}
