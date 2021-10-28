using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Interact
{
    // Start is called before the first frame update
    private PlayerData PD;
    private Player player;
    private Vector3 Throw = Vector3.forward;
    private Vector3 rotation = new Vector3( 0, 0, 0 );

    private bool holding; // detects when player has something in their hand

    public P_Interact(PlayerData PD)
    {
        this.PD = PD;
        this.player = PD.player;
    }

    public void Interact()
    {
        Ray ray = PD.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;// holds data on what is infront of the player
        Physics.Raycast(ray, out hit);// finds what is infront of the player
        Physics.Raycast(ray, out hit);
        if (hit.collider != null)
        {
            switch (hit.collider.tag) //determins if hit is interactable
            {
                case "Door":
                    InteractWithDoor(hit.collider.gameObject);
                    break;
                case "PickUpObject":
                    PickUpObject(hit.collider.gameObject);
                    break;
                case "HidingPlace":
                    Debug.Log("so hidden wow");
                    InteractWithHidingPlace(hit.collider.gameObject);
                    break;
                default:
                    break;

            }
        }
        
    }
    private void InteractWithDoor(GameObject door)
    {
        door.GetComponent<Door>().interactWith();
    }
    public void InteractWithHidingPlace(GameObject HP)
    {
        HP.GetComponent<HidingPlace>().interactWith(PD);

    }
    private void PickUpObject(GameObject obj)
    {
        //Attaches OBJ to player in a visable way
        //prevents you from picking up something else
        Debug.Log("pickup");
        if (PD.inHand == null)
        {
            GameObject hand = GameObject.Find("Hand");
            PD.inHand = obj;
            obj.GetComponent<BoxCollider>().enabled = false;// turns off object collisions
            obj.GetComponent<Rigidbody>().useGravity = false; // turns off object so it can be in hand
            obj.transform.SetPositionAndRotation(player.hand.position,PD.cam.transform.rotation);
            obj.GetComponent<Rigidbody>().freezeRotation = true;
            obj.GetComponent<Rigidbody>().velocity = rotation;
            //obj.transform.position = player.hand.position; // fixes object to player hand position
            obj.transform.parent = hand.transform;// fixes object to players position/movment
        }
        //allows you to throw something
    }
     public void ThrowHandObj()
    {
        GameObject obj = PD.inHand;
        PD.inHand = null;
        obj.transform.parent = null;
        obj.GetComponent<Rigidbody>().useGravity = true;
        obj.GetComponent<BoxCollider>().enabled = true;
        obj.GetComponent<Rigidbody>().freezeRotation = false;
        obj.GetComponent<Rigidbody>().velocity = (obj.transform.forward * PD.throwForce);


    }
    
    public void PlaceObject()
    {

    }
}
