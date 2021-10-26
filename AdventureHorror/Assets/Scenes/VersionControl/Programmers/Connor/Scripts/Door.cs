using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public bool open = false;
    private bool locked = false;
    public Animator doorAnimator;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
    }
    public void Open()
    {
        if (!locked)
        {
          // doorAnimator.pla
        }
    }
    public void Close()
    {

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
