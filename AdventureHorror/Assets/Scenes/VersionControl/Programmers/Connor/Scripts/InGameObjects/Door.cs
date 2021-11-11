using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public WireData WD;
    public bool isOpen = false;
    public bool locked = false;
    private bool canOpen = true;
    private Collider collider;
    public Animator doorAnimator;
    //public PuzzlePoster poster;
    //private List<Wire> wires = new List<Wire>();

    private void Start()
    {
        if (WD != null)
            WD.door = this;
        collider = gameObject.GetComponent<Collider>();
        if (isOpen)
        {
            Open();
        }

    }
    public void Open()
    {


        if (!locked && canOpen)
        {
            Debug.Log("door is opening");
            isOpen = true;
            doorAnimator.SetBool("doorOpen", true);
            StartCoroutine(CanOpenOrClose());



        }
    }
    public void Close()
    {
        if (canOpen)
        {
            doorAnimator.SetBool("doorOpen", false);
            isOpen = false;
            StartCoroutine(CanOpenOrClose());
        }

    }
    IEnumerator CanOpenOrClose()
    {
        canOpen = false;
        collider.enabled = false;
        yield return new WaitForSeconds(1f);
        canOpen = true;
        collider.enabled = true;
    }
    public void Unlock()
    {
        Debug.Log("door is unlocking");
        locked = false;
        Debug.Log(locked);
    }
    public void Lock()
    {
        locked = true;
    }
    public void interactWith()
    {
        if (!isOpen)
        {
            Open();// opens door/plays door opening animaition.
        }
        else
        {
            Close();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(collider.tag);
        if ((collider.tag == "Player" || collider.tag == "Papa") && !isOpen)
        {
            Open();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if ((collider.tag == "Player" || collider.tag == "Papa") && isOpen)
        {
            Close();
        }
    }




    //public void RemoveWire(Wire wire)
    //{
    //    wires.Remove(wire);
    //    if (wires.Count == 0)
    //    {
    //        Unlock();
    //        Open();
    //    }

    //}

    //public void AddWire(Wire wire)
    //{
    //    wires.Add(wire);
    //    Lock();
    //}
}
