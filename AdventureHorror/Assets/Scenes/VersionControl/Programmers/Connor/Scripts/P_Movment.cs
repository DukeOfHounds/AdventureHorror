using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Movment
{
    // Start is called before the first frame update

    static private float xRotation = 0f;// used to limit potential jarring/neck breaking camera angles

    private PlayerData PD;
    private Player player;

    public P_Movment(PlayerData PD, Player player)
    {
        this.PD = PD;
        this.player = player;

    }
    public void UpdateCamera(float mouseX, float mouseY)
    {
        xRotation -= mouseY; // inverts mouse look
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// prevents the player from over rotating/ overstretching their neck.
        PD.cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);// handles camera Up down movment

        player.transform.Rotate(Vector3.up * mouseX);// handles camera left right movment
    }
}
