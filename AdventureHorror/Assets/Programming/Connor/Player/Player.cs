using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{


    public float mouseX;
    public float mouseY;
    public float vertical1D;
    public float horizontal1D;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Transform hand;
    public Transform toolHand;
    public GameObject deathMenu;
    public GameObject pauseMenu;
    public PauseMenu pm;

    public  GameObject pauseMenuRef;

    public PlayerData PD;
    public PapaData ppD;
    // public P_Input input;
    [HideInInspector]
    public P_Movment movment;
    public P_Inventory inventory;
    public P_Interact interact;
    public DeathSounds deathsounds;
    public bool dead = false;
    public bool paused = false;


    ////////////////Update/Start/Awake////////////////
    ////////////////Update/Start/Awake////////////////

    public void Awake()
    {
        Instantiate(PD.HUD);
        deathsounds = GetComponent<DeathSounds>();
        PD.audioManager = FindObjectOfType<AudioManager>();
        PD.inToolHand = null;
        PD.inHand = null;
        PD.hand = hand;
        PD.toolHand = toolHand;
        PD.cam = Camera.main;
        PD.player = this;
        //input = new P_Input(PD, this);
        movment = new P_Movment(PD);
        inventory = new P_Inventory(PD);
        interact = new P_Interact(PD);

        Cursor.visible = false; // hides cursor 
        Cursor.lockState = CursorLockMode.Confined;// locks cursor to game window
        PD.isHiding = false;
        PD.inHand = null;
       


    }
    void Update()
    {
        if (!dead && !paused)
        {
            Cursor.visible = false;
            movment.UpdateCamera(mouseX, mouseY);
            if (!PD.isHiding)
            {
                movment.UpdatePosition(horizontal1D, vertical1D);
                interact.InteractCheck();
            }
        }
    }
    ////////////////Update/Start/Awake////////////////
    ////////////////Update/Start/Awake////////////////

    public void Death()
    {
        if (!dead)
        {
            deathsounds.PlayDeathSound();
            dead = true;
            Instantiate(deathMenu);
            deathMenu.GetComponent<Animator>().SetBool("StopAnim", true);
            Cursor.visible = true;
            paused = true;
        }
    }





    #region Input Methods
    public void OnMouseLook(InputAction.CallbackContext context)
    {

        mouseX = context.ReadValue<Vector2>().x * PD.mouseSensitivity;
        mouseY = context.ReadValue<Vector2>().y * PD.mouseSensitivity;
    }
    public void OnHorizontalMove(InputAction.CallbackContext context)
    {
        horizontal1D = context.ReadValue<float>();

    }
    public void OnVerticaleMove(InputAction.CallbackContext context)
    {
        vertical1D = context.ReadValue<float>();

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        movment.Jump();

    }
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.performed)// please work 
            interact.Interact();

    }
    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (PD.inHand != null)
        {
            interact.ThrowHandObj();
        }

    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (pauseMenuRef == null &&! dead)
        {
            pauseMenuRef = Instantiate(pauseMenu);
            pm = pauseMenu.GetComponentInChildren<PauseMenu>();
            pm.PauseGame(this.gameObject);
        }
    }
    #endregion

}


