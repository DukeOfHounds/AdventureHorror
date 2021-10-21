using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Inventory
{
    private PlayerData PD;
    private Player player;

    public P_Inventory(PlayerData PD, Player player)
    {
        this.PD = PD;
        this.player = player;
    }

    public void EatBair()
    {
        //plays animation eating bair
        //removes Bair from hands
        //plays animatio finding Bair heart
        //adds heart to PD.BairHearts
        // applys Bair Buff

    }
}
