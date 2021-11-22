using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/Generic")]


public class PlayerData : ScriptableObject
{
    [SerializeField]
    [Header("Player")]
    public List<GameObject> BairHearts;
    public List<GameObject> tools;
    public GameObject inHand = null;
    public P_Input input;
    public P_Interact interact;
    public P_Inventory inventory;
    public P_Movment movment;
    public GameObject inToolHand;



    [Header("Movment Variables")]
    [Range(0,20)]
    public float speed = 12f; // speed at which the player moves by default. 
    [Range(0, 10)]
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    [Range(0, 100)]
    public float throwForce = 20;

    [Header("Camera Variables")]
    [Range(0, 1)]
    public float mouseSensitivity = .1f;
    public float InteractRange = 3;
    public Canvas HUD;
  
    [Header("Fear Variables")]
    public int fear;
    public int fearThreshold;

    [HideInInspector]
    public Camera cam;// the camera following the player
    public bool isHiding = false;
    public Player player;//the player object
    public Transform hand;
    public Transform toolHand;
    public AudioManager audioManager;

}
