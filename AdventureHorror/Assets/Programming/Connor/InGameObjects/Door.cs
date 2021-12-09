using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Door : MonoBehaviour
{
    public WireData WD;
    public bool isOpen = false;
    public bool locked = false;
    private bool canOpenOrClose = true;
    private Collider collider;
    public Animator doorAnimator;
    AudioSource sound;
    float doorOpenTime = 0;
    bool stayOpen = false;
    //AudioManager audioManager;
    //Sound s;
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
        //else StartCoroutine(dontStayOpen());
    }

    IEnumerator dontStayOpen()
    {
        yield return new WaitForSeconds(2f);
    }
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        //audioManager = FindObjectOfType<AudioManager>();
        // s = Array.Find(audioManager.sounds, sound => sound.name == "Metal sliding door 2");

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
            StartCoroutine(PlaySound());
            StartCoroutine(CanOpenOrClose());



        }
    }
    public void Close()
    {
        if (canOpenOrClose)
        {
            isOpen = false;
            doorAnimator.SetBool("doorOpen", false);
            StartCoroutine(PlaySound());
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
    public IEnumerator PlaySound()
    {
        if (sound.isPlaying)
        {
            sound.Stop();

        }
        sound.Play();
        yield return new WaitForSeconds(1f);
        sound.Stop();


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
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("opensaysme: " + other.name);
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
        //Debug.Log("CLOSE DAMN IT: "+ other.name);

        if ((other.tag == "Player" || other.tag == "Papa") && isOpen)
        {
            Close();
        }
       

    }

    //public void OnTriggerStay(Collider other)
    //{
    //    Debug.Log(other.name);
    //    //if (other.tag == "Player" || other.tag == "Papa")
    //    //{
    //    //    stayOpen = true;
    //    //}
    //}
}
