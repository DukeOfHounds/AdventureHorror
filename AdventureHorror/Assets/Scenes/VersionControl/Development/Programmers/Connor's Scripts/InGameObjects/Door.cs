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
    float doorOpenTime = 0;
    bool stayOpen = false;
    //public PuzzlePoster poster;
    //private List<Wire> wires = new List<Wire>();

    private void Update()
    {
        //if (isOpen && !stayOpen)
        //{
        //    //doorOpenTime += Time.deltaTime;
        //    //if (doorOpenTime >= 10f)
        //    //{
        //    Close();
        //    doorOpenTime = 0;
        //    //}


        //}
        //else StartCoroutine(wait());
    }
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
            isOpen = true;
            doorAnimator.SetBool("doorOpen", true);
            StartCoroutine(CanOpenOrClose());



        }
    }
    public void Close()
    {
        if (canOpenOrClose)
        {
            isOpen = false;
            doorAnimator.SetBool("doorOpen", false);
            StartCoroutine(CanOpenOrClose());
            doorOpenTime = 0;
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
    //IEnumerator wait()
    //{
    //    stayOpen = false;
    //    yield return new WaitForSeconds(1f);
       

    //}
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
    public void OnTriggerEnter(Collider other)
    {
        
        if ((other.tag == "Player" || other.tag == "Papa") && !isOpen)
        {
            stayOpen = true;
            Open();
        }
        //else if(other.tag != "Player" && other.tag != "Papa" && isOpen)
        //{
        //    stayOpen = false;
        //}
    }
    public void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Papa") && isOpen)
        {
            Close();
        }
        
    }
    //public void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player" || other.tag == "Papa")
    //    {
    //        stayOpen = true;
    //    }
    //}
}
