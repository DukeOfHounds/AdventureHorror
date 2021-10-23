using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/Generic")]


public class PlayerData : ScriptableObject
{
    [SerializeField]
    [Header("Player (Ignore cam)")]
    public List<GameObject> BairHearts;
    public GameObject inHand = null;
    public GameObject player;//the player object
    public Camera cam;// the camera following the player

    [Header("Movment Variables")]
    public float speed = 12f; // speed at which the player moves by default. 
    public float jumpHeight = 3f;
    public float gravity;

    [Header("Camera Variables")]
    public float mouseSensitivity;

    [Header("Fear Variables")]
    public int fear;
    public int fearThreshold;

    private void OnEnable()
    {
        cam = Camera.main; // assigns camera 
    }






}
