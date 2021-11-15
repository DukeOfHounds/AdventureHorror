using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class P_Input
{
    public float mouseX;
    public float mouseY;
    public float vertical1D;
    public float horizontal1D;

    private PlayerData PD;
    private Player player;

    public P_Input(PlayerData PD, Player player)
    {
        this.PD = PD;
        this.player = player;
    }




    public void OnMouseLook(InputAction.CallbackContext context)
    {

        mouseX = context.ReadValue<Vector2>().x * PD.mouseSensitivity * Time.deltaTime;
        mouseY = context.ReadValue<Vector2>().y * PD.mouseSensitivity * Time.deltaTime;
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
        player.movment.Jump();
        
    }
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        //Ray ray = PlayerInstance.instance.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //RaycastHit hit;
        //Physics.Raycast(ray, out hit);

    }

}
