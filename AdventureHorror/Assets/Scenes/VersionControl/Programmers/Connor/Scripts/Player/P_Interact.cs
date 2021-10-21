using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Interact
{
    // Start is called before the first frame update
    private PlayerData PD;
    private Player player;

    public P_Interact(PlayerData PD, Player player)
    {
        this.PD = PD;
        this.player = player;
    }

    public void Interact()
    {
        Ray ray = PlayerInstance.instance.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;// holds data on what is infront of the player
        Physics.Raycast(ray, out hit);// finds what is infront of the player
        switch (hit.collider.tag) //determins if hit is interactable
        {
            case "Door":
                OpenDoor(hit.collider.gameObject);
                break;
            case "Bair":
                PickUpBair(hit.collider.gameObject);
                break;
            default:
                break;

        }
    }
    private void OpenDoor(GameObject door)
    {
        // opens door/plays door opening animaition.
    }
    private void PickUpBair(GameObject bair)
    {
        //remvoes bair from scene
        //adds bair visual to hands
        //prevents you from picking up something else
        //allows you to throw something
    }
}
