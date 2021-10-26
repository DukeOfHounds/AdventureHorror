using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool locked = false;
    private bool canOpen = true;
    public Animator doorAnimator;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
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
        yield return new WaitForSeconds(1f);
        canOpen = true;
    }
    public void Unlock()
    {
        locked = false;
    }
    public void Lock()
    {
        locked = true;
    }
}
