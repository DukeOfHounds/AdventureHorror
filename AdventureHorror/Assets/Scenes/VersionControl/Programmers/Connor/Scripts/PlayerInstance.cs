using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    #region Singleton

    public static PlayerInstance instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<GameObject> Bairs;
    public GameObject player;//the player object
    public Camera cam;// the camera following the player
    public float speed = 12f; // speed at which the player moves by default. 
    public float JumpHeight = 3f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
}


