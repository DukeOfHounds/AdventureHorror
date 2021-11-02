using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class P_Inventory
{
    private PlayerData PD;
    private Player player;
    public P_Inventory(PlayerData PD)
    {
        this.PD = PD;
        this.player = PD.player;
    }

    public void ThrowObj()
    {
        GameObject obj = PD.inHand;

    }
}
