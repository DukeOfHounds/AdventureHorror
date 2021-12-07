using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPortal : MonoBehaviour
{
    public VentPortal ventPortalOfExit;
    public GameObject ventOfExit;
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
            StartCoroutine(TeleportPosition(ventPortalOfExit.ExitPosition, 1f));
        }
    }
    IEnumerator TeleportPosition(Transform targetPosition, float duration)
    {
         StartCoroutine(ventOfExit.GetComponent<Panel>().ForceRemove());
        float time = 0;
        Vector3 startPosition = PD.player.gameObject.transform.position;
        while (time < duration)
        {
            PD.player.gameObject.transform.position = targetPosition.position;
            //rotating the player is headache indusing so maybe wait until later
            time += Time.deltaTime;
            yield return null;
        }

        TP = true;

    }
}
