using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPortal : MonoBehaviour
{
    public VentPortal VentOfExit;
    public Transform ExitPosition;
    public PlayerData PD;
    public void Teleport()
    {
        PD.player.transform.position = VentOfExit.ExitPosition.transform.position;// teleports player
    }
}
