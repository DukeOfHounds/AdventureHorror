using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBehavior : MonoBehaviour
{

    public Friend friendType;
    public Animator friendAnimator;
    private bool isPlaying;
    //public FriendData FD;
    PlayerData PD;

    public enum Friend
    {
        Bair,
        Octopus,
        GuineaPig,
        Snake,
        Rabbit,
        Monkey,
        Hippo,
        TRex

    }
    // Start is called before the first frame update
    void Start()
    {
        PD = GameObject.FindObjectOfType<Player>().PD;
    }

    public void PickUp()
    {
        GameObject tool;
        try
        {
            tool = GetComponentInChildren<Tool>().gameObject;
            PD.tools.Add(tool);
            Interact();
        }
        catch
        {
            Debug.LogError("No Tool");
        }
    }







    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator PlayAnimation(int index, float time)
    {
        //if (!isPlaying)
        //{
        isPlaying = true;
        friendAnimator.SetInteger("State", index);
        yield return new WaitForSeconds(time);
        isPlaying = false;
        //Interact();
        // }
        //else
        //{
        //yield return new WaitForSeconds(1f);
        //StartCoroutine(PlayAnimation(index, time));
        //}
    }

    private void Interact()
    {
        switch (friendType)
        {
            case Friend.Bair:
                StartCoroutine(PlayAnimation(1, 1));
                break;
            case Friend.Octopus:
                StartCoroutine(PlayAnimation(2, 1));
                break;
            case Friend.GuineaPig:
                StartCoroutine(PlayAnimation(0, 1));
                break;
        }
    }

    public void PlayPickUpAnimation()
    {
        switch (friendType)
        {
            case Friend.Bair:
                StartCoroutine(PlayAnimation(2, 1));
                break;
            case Friend.Octopus:
                StartCoroutine(PlayAnimation(3, 1));
                break;
            case Friend.GuineaPig:
                StartCoroutine(PlayAnimation(0, 1));
                break;
        }
    }
}
