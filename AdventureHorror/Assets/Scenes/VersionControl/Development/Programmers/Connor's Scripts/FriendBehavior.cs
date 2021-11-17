using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBehavior : MonoBehaviour
{
    public Friend friendType;
    public Animator friendAnimator;

    public enum Friend
    {
        Bair,
        Octopus,
        GuineaPig

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        switch (friendType)
        {
            case Friend.Bair:
                StartCoroutine(PlayAnimation(0,0));
                break;
            case Friend.Octopus:

                break;
            case Friend.GuineaPig:

                break;
        }
    }

    IEnumerator PlayAnimation(int index, float time)
    {
        if (friendAnimator.GetBool("IsPlaying"))
        {
            friendAnimator.SetBool("IsPlaying", true);
            friendAnimator.SetInteger("state", index);
            yield return new WaitForSeconds(time);
            friendAnimator.SetBool("IsPlaying", false);
        }
        Initialize();
    }
}
