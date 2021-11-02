using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/Generic")]


public class PlayerData : ScriptableObject
{
    [SerializeField]
    [Header("Player")]
    public List<GameObject> BairHearts;
    public GameObject inHand = null;
    public P_Input input;
    public P_Interact interact;
    public P_Inventory inventory;
    public P_Movment movment;
    public Transform hand;



    [Header("Movment Variables")]
    public float speed = 12f; // speed at which the player moves by default. 
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float throwForce = 20;

    [Header("Camera Variables")]
    public float mouseSensitivity = 33;

    [Header("Fear Variables")]
    public int fear;
    public int fearThreshold;

    [Header("IgnoreDoNotTouch")]
    public Camera cam;// the camera following the player
    public bool isHiding = false;
    public Player player;//the player object


    private void OnEnable()
    {
        cam = Camera.main; // assigns camera 
    }







}
