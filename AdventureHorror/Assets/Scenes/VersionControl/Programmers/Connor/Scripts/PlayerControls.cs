using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    ////////////////Variables////////////////
    ////////////////Variables////////////////
  
    private Transform playerBody;//what is doing the turning left right
    private Transform playerCam;//what is doing the looking up down
    private CharacterController controller;
    private Transform groundCheck;
    private LayerMask groundMask;
    private float groundDistance;

    public float mouseSensitivity = 100f;// mouse sensitivity to change aka how quickly you turn
    private float moveSpeed;
    private float jumpHeight;

    private bool isGrounded;
    private float gravity;
    Vector3 velocity;

    private float mouseX;// mouse left right input
    private float mouseY; // mouse up down input
    private float xRotation = 0f;// used to limit potential jarring/neck breaking camera angles
    private float horizontal1D; //w s key inputs for movment
    private float vertical1D; // a d key inputs for movment
    ////////////////Variables////////////////
    ////////////////Variables////////////////








    ////////////////Update/Start/Awake////////////////
    ////////////////Update/Start/Awake////////////////
    private void Start()
    {
        playerBody = PlayerInstance.instance.player.transform;
        playerCam = PlayerInstance.instance.cam.transform;
        groundCheck = PlayerInstance.instance.groundCheck;
        groundDistance = PlayerInstance.instance.groundDistance;
        groundMask = PlayerInstance.instance.groundMask;
        jumpHeight = PlayerInstance.instance.JumpHeight;

        controller = PlayerInstance.instance.player.GetComponent<CharacterController>();
        Cursor.visible = false; // hides cursor 
        Cursor.lockState = CursorLockMode.Confined;// locks cursor to game window
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        moveSpeed = PlayerInstance.instance.speed;
        gravity = PlayerInstance.instance.gravity;

        xRotation -= mouseY; // inverts mouse look
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// prevents the player from over rotating/ overstretching their neck.
        playerCam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);// handles camera Up down movment

        playerBody.Rotate(Vector3.up * mouseX);// handles camera left right movment
        //playerBody.Rotate(Vector3.left * mouseY); // using this will have the camera rotate to the point of not keeping it parrallel with the ground
        Vector3 move = playerBody.right * horizontal1D + transform.forward * vertical1D;

        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;// lets the player walk on the ground
        controller.Move(velocity *Time.deltaTime);
    }
    ////////////////Update/Start/Awake////////////////
    ////////////////Update/Start/Awake////////////////









    ////////////////Getters/Setters////////////////
    ////////////////Getters/Setters////////////////

    /// <summary>
    /// simple getter for mouse sensitivity
    /// </summary>
    /// <returns>an ingeger repersentation of mouse sensitvity </returns>
    public int GetMouseSensitivity()
    {
        return (int)mouseSensitivity;
    }
    /// <summary>
    /// simple setter for mouse sensitivity, will be used in Menu system.
    /// </summary>
    public void SetMouseSensitivity(int newMouseSensitivity)
    {
        mouseSensitivity = (float)newMouseSensitivity;
    }
    ////////////////Getters/Setters////////////////
    ////////////////Getters/Setters////////////////
















    ////////////////Input Methods////////////////
    ////////////////Input Methods////////////////
    #region Input Methods
    public void OnMouseLook(InputAction.CallbackContext context)
    {

        mouseX = context.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        mouseY = context.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;
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

        if (isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    #endregion
    ////////////////Input Methods////////////////
    ////////////////Input Methods////////////////
}


