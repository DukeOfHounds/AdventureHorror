using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public Transform hidingSpot;
    public Transform ExitSpot;

    private Door door;
    public bool isHiding;

        private void Awake()
    {
        door = GetComponent<Door>();
    }


    
    public void interactWith(PlayerData PD)
    {
        

        if (!isHiding)
        {
            StartCoroutine(Hide(PD));
        }
        else
        {
            StartCoroutine(Unhide(PD));
        }
    }
    IEnumerator Unhide(PlayerData PD)
    {
        door.Open();//Open Door
        yield return new WaitForSeconds(.2f);
        // Lerp player.transform out of hidingPlace.transform
        //re-enable wasd  
        yield return new WaitForSeconds(1f);
        door.Close();//door closes
        yield return new WaitForSeconds(1f);
        isHiding = false;
        PD.isHiding = isHiding;

    }
    IEnumerator Hide(PlayerData PD)
    {
        isHiding = true;
        PD.isHiding = isHiding;
        door.Open();//Door Opens
        yield return new WaitForSeconds(.2f);
        //Lerp player.transform to hidingPlace.transform
        //revoke wasd
        yield return new WaitForSeconds(1f);
        door.Close();//door closes
        yield return new WaitForSeconds(1f);

    }
    //Player presses "left click"
    //switch on off
    //off


    //on

}
