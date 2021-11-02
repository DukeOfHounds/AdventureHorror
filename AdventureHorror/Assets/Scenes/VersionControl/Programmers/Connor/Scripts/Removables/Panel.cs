using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : RemovableObjects
{
    private List<GameObject> screws;
    public void Awake()
    {
        removable = Removable.Panel;
        screws = new List<GameObject>();

    }
    public override void Remove()
    {

        if (screws.Count == 0)
        {
            Debug.Log("remove panel");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

        }

    } 
    public void AddScrewToList(GameObject screw)
    {
        screws.Add(screw);
        Debug.Log("adding screw");
    }
    public void RemoveScrewFromList(GameObject screw)
    {
        screws.Remove(screw);

    }
}
