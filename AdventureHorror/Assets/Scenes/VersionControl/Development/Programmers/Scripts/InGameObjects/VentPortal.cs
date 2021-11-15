using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPortal : MonoBehaviour
{
    public VentPortal VentOfExit;
    public Transform ExitPosition;
    public PlayerData PD;
    public bool canExit = false;

    private static bool TP = true;
    public void Teleport()
    {
        if (TP == true)
        {
            Debug.Log("woosh woosh woosh");
            TP = false;
            StartCoroutine(TeleportPosition(VentOfExit.ExitPosition, 1f));
        }
    }
    IEnumerator TeleportPosition(Transform targetPosition, float duration)
    {
        if (VentOfExit.canExit)
        {
            float time = 0;
            Vector3 startPosition = PD.player.gameObject.transform.position;
            while (time < duration)
            {
                PD.player.gameObject.transform.position = targetPosition.position;
                //rotating the player is headache indusing so maybe wait until later
                time += Time.deltaTime;
                yield return null;
            }
        }
            TP = true;
        
    }
}
