using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool locked = false;
    private bool canOpen = true;
    private Collider collider;
    public Animator doorAnimator;
    public PuzzlePoster poster;
    private List<Wire> wires = new List<Wire>();

    private void Start()
    {
        collider = gameObject.GetComponent<Collider>();
        if(isOpen)
        {
            Open();
        }

    }
    public void Open()
    {
        if (!locked && canOpen)
        {
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
        locked = false;
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
    public void RemoveWire(Wire wire)
    {
        wires.Remove(wire);
        if (wires.Count == 0)
        {
            Unlock();
            Open();
        }

    }

    public void AddWire(Wire wire)
    {
        wires.Add(wire);
        Lock();
    }
}
