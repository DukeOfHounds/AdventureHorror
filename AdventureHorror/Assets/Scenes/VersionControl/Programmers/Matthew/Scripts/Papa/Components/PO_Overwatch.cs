using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PO_Overwatch
{

    private Vector3 spawnPoint;
    bool spawnPointSet;
    private float spawnPointRange;
    //Scriptable Object Variables 
    public PapaData papaData;
    public Papa papa;
    private GameObject paparef;
    private Overwatch overwatch;

    //Constructor
    public PO_Overwatch(PapaData papaData, Papa papa, Overwatch overwatch)
    {
        this.papaData = papaData;
        this.papa = papa;
        this.paparef = papaData.Papa;
        this.overwatch = overwatch;
    }


    public void GetLocation()
    {
        if (!spawnPointSet)
            SearchSpawnPoint();

        if (spawnPointSet)
        {
            if(papaData.isActive)
            {
                papa.agent.SetDestination(spawnPoint);
            }
            else
            {
                Debug.Log("Hello");
                paparef.transform.position = spawnPoint;
                //papa.ppM.currentState = PP_Movement.State.StartSearch;
                papaData.isActive = true;
                papa.Refresh();
            }
        }

    }

    private void SearchSpawnPoint()
    {
        spawnPoint = RandomPointInAnnulus(papaData.player.transform.position, papaData.papaMinDespawnDist, papaData.papaMaxDespawnDist);
        Vector3 distToPlayer = spawnPoint - papaData.player.transform.position;
        Debug.DrawLine(spawnPoint, papaData.player.transform.up * 100, Color.green, 100f);
        if (Physics.Raycast(spawnPoint, papaData.player.transform.up, 1f, papaData.occlusionLayers))
            spawnPointSet = true;

    }



    public Vector3 RandomPointInAnnulus(Vector2 origin, float minRadius, float maxRadius)
    {

    var randomDirection = (Random.insideUnitCircle * origin).normalized;

    var randomDistance = Random.Range(minRadius, maxRadius);

    var point = origin + randomDirection * randomDistance;

    return point;
    }
}
