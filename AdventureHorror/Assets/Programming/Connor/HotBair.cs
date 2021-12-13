using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBair : MonoBehaviour
{
    //public bool[] aquireds;
    public GameObject[] slots;
    public GameObject bairIcon;
    public GameObject snakeIcon;
    public GameObject guineaPigIcon;
    public GameObject flashlightIcon;
    public GameObject screwDriverIcon;
    public GameObject wireCutterIcon;


    // Start is called before the first frame update
    void Start()
    {
        bairIcon = Instantiate(bairIcon, slots[0].transform, false);
        guineaPigIcon = Instantiate(guineaPigIcon, slots[1].transform, false);
        snakeIcon = Instantiate(snakeIcon, slots[2].transform, false);


    }
    public void AquireFriend(FriendBehavior.Friend friend)
    {
        switch (friend)
        {
            case FriendBehavior.Friend.Bair: // slot 0
                SwitchIcon(bairIcon, flashlightIcon, slots[0]);
                break;
            case FriendBehavior.Friend.GuineaPig:// slot 1
                SwitchIcon(guineaPigIcon, screwDriverIcon, slots[1]);
                break;
            case FriendBehavior.Friend.Snake:// slot 2
                SwitchIcon(snakeIcon, wireCutterIcon, slots[2]);
                break;
            default:

                break;
        }
    }
    void SwitchIcon(GameObject oldIcon, GameObject newIcon, GameObject slot)
    {
        Destroy(oldIcon);
        Instantiate(newIcon, slot.transform, false);
    }
}
