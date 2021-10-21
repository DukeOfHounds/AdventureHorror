using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName ="PlayerData/Generic")]


public class PlayerData : ScriptableObject
{

    public List<GameObject> Bairs;
    public GameObject player;//the player object
    public Camera cam;// the camera following the player

    [Header("Movment Variables")]
    public float speed = 12f; // speed at which the player moves by default. 
    public float JumpHeight = 3f;
    public float gravity;

    [Header("Camera Variables")]
    public float mouseSensitivity;




    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    public int fear;
    public int fearThreshold;








}
