using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public WireData WD;
    public bool isOpen = false;
    public bool locked = false;
    private bool canOpenOrClose = true;
    private Collider collider;
    public Animator doorAnimator;
    //public PuzzlePoster poster;
    //private List<Wire> wires = new List<Wire>();

    private void Start()
    {
        if (WD != null)
        {
            WD.door = this;
            Lock();
        }
        collider = gameObject.GetComponent<Collider>();
        if (isOpen)
        {
            Open();
        }

    }
    public void Open()
    {


        if (!locked && canOpenOrClose)
        {
            Debug.Log("door is opening");
            isOpen = true;
            doorAnimator.SetBool("doorOpen", true);
            StartCoroutine(CanOpenOrClose());



        }
    }
    public void Close()
    {
        if (canOpenOrClose)
        {
            doorAnimator.SetBool("doorOpen", false);
            isOpen = false;
            StartCoroutine(CanOpenOrClose());
        }

    }
    IEnumerator CanOpenOrClose()
    {
        canOpenOrClose = false;
        collider.enabled = false;
        yield return new WaitForSeconds(1f);
        canOpenOrClose = true;
        collider.enabled = true;
    }
    IEnumerator waitThenClose()
    {
        Debug.Log("wait then close");
        yield return new WaitForSeconds(1f);
        Close();
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
        if ((other.tag == "Player" || other.tag == "Papa") && !isOpen)
        {
            Open();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log(isOpen);
        if ((other.tag == "Player" || other.tag == "Papa") && isOpen)
        {
            Debug.Log(canOpenOrClose);
            if (canOpenOrClose) Close();
            else waitThenClose();
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
