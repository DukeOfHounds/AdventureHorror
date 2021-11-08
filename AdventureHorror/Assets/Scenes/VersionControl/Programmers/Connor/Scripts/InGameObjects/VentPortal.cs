using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPortal : MonoBehaviour
{
    public VentPortal VentOfExit;
    public Transform ExitPosition;
    public PlayerData PD;

    private static bool TP = true;
    public void Teleport()
    {
        if (TP == true)
        {
            Debug.Log("woosh woosh woosh");
            TP = false;
            StartCoroutine(TeleportPosition(VentOfExit.ExitPosition, 1f));
        }
        //PD.player.transform.position = VentOfExit.ExitPosition.transform.position;// teleports player
        //PD.player.gameObject.transform.position = new Vector3(VentOfExit.ExitPosition.transform.position.x, VentOfExit.ExitPosition.transform.position.y, VentOfExit.ExitPosition.transform.position.z);
    }
    IEnumerator TeleportPosition(Transform targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = PD.player.gameObject.transform.position;

        while (time < duration)
        {
            PD.player.gameObject.transform.position = targetPosition.position;
            //PD.player.gameObject.transform.rotation = new Quaternion(PD.player.gameObject.transform.rotation.x,
            //    VentOfExit.transform.rotation.y, PD.player.gameObject.transform.rotation.z, PD.player.gameObject.transform.rotation.w);
            time += Time.deltaTime;
            yield return null;
        }
        PD.player.gameObject.transform.position = targetPosition.position;
        PD.player.gameObject.transform.position = PD.player.gameObject.transform.position;
        TP = true;
    }
}
