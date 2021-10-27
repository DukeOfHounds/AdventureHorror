using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public GameObject hidingSpot;
    public Door door;
    public bool isHiding;

        private void Awake()
    {
        door = hidingSpot.GetComponent<Door>();
    }
    public void Hide()
    {

        door.Open();//Door Opens
        //Lerp player.transform to hidingPlace.transform
        //revoke wasd
        door.Close();//door closes
    }

    public void Unhide()
    {

        door.Open();//Open Door
        // Lerp player.transform out of hidingPlace.transform
        //re-enable wasd  
        door.Close();//door closes
    }
    public void interactWith()
    {
        if (!isHiding)
        {
            Hide();
        }
        else
        {
            Unhide();
        }
    }


//Player presses "left click"
//switch on off
//off


    //on
    
}
