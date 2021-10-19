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

    public GameObject player;//the player object
    public Camera cam;// the camera following the player


}


