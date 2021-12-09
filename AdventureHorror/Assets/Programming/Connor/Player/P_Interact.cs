using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Interact
{
    // Start is called before the first frame update
    private PlayerData PD;
    private Player player;
    private Vector3 rotation = new Vector3(0, 0, 0);
    private RemovableObjects rm;
    private HotBair hotbair;
    public P_Interact(PlayerData PD)
    {
        this.PD = PD;
        this.player = PD.player;
        this.hotbair = GameObject.FindGameObjectWithTag("Hud").GetComponentInChildren<HotBair>();
    }

    public void InteractCheck()
    {

        Ray ray = PD.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;// holds data on what is infront of the player
        Physics.Raycast(ray, out hit, PD.InteractRange);// finds what is infront of the player
        if (hit.collider != null)
        {

            if (hit.collider.tag.Equals("Manipulable")) //determins if hit is Manipulable
            {
                rm = hit.collider.gameObject.GetComponent<RemovableObjects>();
                Debug.Log(PD.inventory.hasTool(rm.NeededTool()) + "" + rm.NeededTool());
                if (PD.inventory.hasTool(rm.NeededTool())) // checks to see if you have neccessary tool
                {
                    PD.inventory.DisplayTool(rm.NeededTool()); // displays needed tool
                }
            }
            else
            {
                PD.inventory.HideTool();
            }

        }
        else PD.inventory.HideTool();
    }

    public void Interact()
    {
        Ray ray = PD.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;// holds data on what is infront of the player
        Physics.Raycast(ray, out hit, PD.InteractRange);// finds what is infront of the player
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            switch (hit.collider.tag) //determins if hit is interactable
            {
                //case "Door":
                //    InteractWithDoor(hit.collider.gameObject); // opens or closes door (if you can)
                //    break;
                case "PickUpAble":
                    if (hit.collider.gameObject.name.Contains("Flashlight"))
                    {
                        try
                        {
                            hotbair.AquireFriend(hit.collider.gameObject.GetComponentInParent<FriendBehavior>().friendType);
                        }
                        catch
                        {

                        }
                        PickUpFlashlight(hit.collider.gameObject);
                    }
                    else
                        PickUpObject(hit.collider.gameObject);// picks up PickUp
                    break;
                case "HidingPlace":
                    //Debug.Log("so hidden wow");
                    HideInHidingPlace(hit.collider.gameObject);
                    break;
                case "Manipulable":
                    Manipulate(hit.collider.gameObject);
                    break;
                case "Removable":
                    //Debug.Log("hit removable");
                    RemoveObject(hit.collider.gameObject);
                    break;
                case "Vent":
                    EnterVent(hit.collider.gameObject);
                    break;
                case "Tool":
                    //Debug.Log(hit.collider.gameObject.tag);
                    hotbair.AquireFriend(hit.collider.gameObject.GetComponentInParent<FriendBehavior>().friendType);
                    if (hit.collider.gameObject.GetComponent<Tool>().IsTool().Equals("Flashlight"))
                    {
                        PickUpFlashlight(hit.collider.gameObject);
                    }
                    else
                        AddTool(hit.collider.gameObject);
                    break;
                case "Friend":
                    Debug.Log(hit.collider.gameObject.tag);
                    if (hit.collider.gameObject.GetComponent<FriendBehavior>().friendType == FriendBehavior.Friend.Bair)
                    {
                        try
                        {
                            Debug.Log("give me the flashlight damnit");
                            GameObject obj = hit.collider.gameObject.GetComponentInChildren<Flashlight>().gameObject;
                            obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                            PickUpFlashlight(obj);
                            hotbair.AquireFriend(hit.collider.gameObject.GetComponent<FriendBehavior>().friendType);
                        }
                        catch
                        {
                            hotbair.AquireFriend(hit.collider.gameObject.GetComponent<FriendBehavior>().friendType);
                            PickUpObject(hit.collider.gameObject);
                        }
                        PickUpObject(hit.collider.gameObject);
                    }
                    else
                    {
                        PickUpObject(hit.collider.gameObject);
                        try
                        {

                            hotbair.AquireFriend(hit.collider.gameObject.GetComponent<FriendBehavior>().friendType);
                            AddTool(hit.collider.gameObject.GetComponentInChildren<Tool>().gameObject);

                        }
                        catch
                        {
                            Debug.LogWarning("Friend Has No tool");
                        }
                    }
                    break;
                default:
                    
                    break;
            }
        }
       

    }
    //private void InteractWithDoor(GameObject door)
    //{
    //    door.GetComponent<Door>().interactWith();
    //}
    private void HideInHidingPlace(GameObject HP)
    {
        HP.GetComponent<HidingPlace>().interactWith(PD);

    }
    private void Manipulate(GameObject obj)
    {
        if (PD.inToolHand != null)
            PD.inToolHand.GetComponent<Tool>().Use(obj);
    }
    private void PickUpObject(GameObject obj)
    {

        //Attaches OBJ to player in a visable way
        //prevents you from picking up something else
        //Debug.Log("pickup");
        if (PD.inHand == null)
        {
            GameObject hand = GameObject.Find("Hand");
            if (obj.TryGetComponent(out FriendBehavior fB))
            {
                fB.PlayPickUpAnimation();
            }
            PD.inHand = obj;
            obj.GetComponent<Collider>().enabled = false;// turns off object collisions
            obj.GetComponent<Rigidbody>().useGravity = false; // turns off object so it can be in hand
            obj.transform.SetPositionAndRotation(player.hand.position, PD.cam.transform.rotation);
            obj.GetComponent<Rigidbody>().freezeRotation = true;
            obj.GetComponent<Rigidbody>().velocity = rotation;
            //obj.transform.position = player.hand.position; // fixes object to player hand position
            obj.transform.parent = hand.transform;// fixes object to players position/movment
        }
        //allows you to throw something
    }
    private void PickUpFlashlight(GameObject obj)
    {

        //Attaches OBJ to player in a visable way
        //prevents you from picking up something else
        //Debug.Log("pickup");

        GameObject hand = GameObject.Find("FlashlightHand");
        PD.inFlashlightHand = obj;
        obj.GetComponent<Collider>().enabled = false;// turns off object collisions
        obj.GetComponent<Rigidbody>().useGravity = false; // turns off object so it can be in hand
        obj.transform.SetPositionAndRotation(player.hand.position, PD.cam.transform.rotation);
        obj.GetComponent<Rigidbody>().freezeRotation = true;
        obj.GetComponent<Rigidbody>().velocity = rotation;
        //obj.transform.position = player.hand.position; // fixes object to player hand position
        obj.transform.parent = hand.transform;// fixes object to players position/movment
        obj.transform.position = hand.transform.position;
        obj.GetComponent<Flashlight>().Use();
        //allows you to throw something
    }

    private void RemoveObject(GameObject obj)
    {
        obj.GetComponent<RemovableObjects>().Remove();
    }
    private void EnterVent(GameObject obj)
    {
        obj.GetComponent<VentPortal>().Teleport();
    }
    public void AddTool(GameObject obj)
    {

        //Debug.Log("add tool to inventory");
        PD.inventory.AddTool(obj);
        GameObject toolHand = GameObject.Find("ToolHand");
        obj.transform.parent = toolHand.transform;// fixes object to players position/movment
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        //rb.freezeRotation = false;
        obj.GetComponentInChildren<MeshRenderer>().enabled = false;// turns it invisible until needed
        obj.GetComponent<Collider>().enabled = false;// turns off object collisions
        rb.useGravity = false; // turns off object so it can be in hand
        obj.transform.SetPositionAndRotation(player.toolHand.position, PD.cam.transform.rotation);
        rb.freezeRotation = true;
        rb.velocity = rotation;
        //obj.transform.position = player.hand.position; // fixes object to player hand position
    }

    public void ThrowHandObj()
    {
        GameObject obj = PD.inHand;
        PD.inHand = null;
        obj.transform.parent = null;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.useGravity = true;
        obj.GetComponent<Collider>().enabled = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.velocity = (obj.transform.forward * PD.throwForce);


    }
    
}
