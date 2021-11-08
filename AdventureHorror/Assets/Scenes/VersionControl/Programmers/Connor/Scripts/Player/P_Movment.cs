using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Movment
{
    // Start is called before the first frame update

    static private float xRotation = 0f;// used to limit potential jarring/neck breaking camera angles

    private PlayerData PD;
    private Player player;
    public Transform groundCheck;
    public LayerMask groundMask;
    private bool isGrounded;
    private float groundDistance = .4f;
    private Vector3 velocity;

    public P_Movment(PlayerData PD)
    {
        this.PD = PD;
        this.player = PD.player;
        this.groundCheck = player.groundCheck;
        this.groundMask = player.groundMask;
    }
    public void UpdateCamera(float mouseX, float mouseY)
    {
        xRotation -= mouseY; // inverts mouse look
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// prevents the player from over rotating/ overstretching their neck.
        PD.cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);// handles camera Up down movment

        PD.player.transform.Rotate(Vector3.up * mouseX);// handles camera left right movment
    }
    public void UpdatePosition(float horizontal1D, float vertical1D)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = PD.player.transform.right * horizontal1D + PD.player.transform.forward * vertical1D;

        PD.player.GetComponent<CharacterController>().Move(move * PD.speed * Time.deltaTime);

        velocity.y += PD.gravity * Time.deltaTime;// lets the player walk on the ground
        PD.player.GetComponent<CharacterController>().Move(velocity * Time.deltaTime); // actually moves the player
    }
    public void Jump()
    {

        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(PD.jumpHeight * -2f * PD.gravity);
        }
    }

    public void UpdateLook(Vector3 lookSTarget)
    {

    }
}
