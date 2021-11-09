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

    private GameObject sNode;
    private int index;

    private List<GameObject> spawnNodes = new List<GameObject>();
    Collider[] colliders = new Collider[10];

    int count;

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

        else
        {
            if(papaData.isActive)
            {
                papa.agent.SetDestination(spawnPoint);
            }
            else
            {
                paparef.transform.position = spawnPoint;
                //papa.ppM.currentState = PP_Movement.State.StartSearch;
                papaData.isActive = true;
                papa.Refresh();
            }
        }

    }

    private void SearchSpawnPoint()
    {

        if (spawnNodes.Count == 0)
        {

            papa.agent.speed = papaData.papaBaseSpeed;
            count = Physics.OverlapSphereNonAlloc(papa.pD.player.gameObject.transform.position, 500f, colliders, papaData.spawnNodeLayer, QueryTriggerInteraction.Collide);
            for (int i = 0; i < count; ++i)
            {
                if (papaData.canSeeTarget)
                {
                    break;
                }
                else
                {
                    GameObject obj = colliders[i++].gameObject;

                    Vector3 distanceToDest = papa.pD.player.gameObject.transform.position - obj.transform.position;
                    if (distanceToDest.magnitude > 30)
                    {
                        spawnNodes.Add(obj);
                        break;
                    }
                }

            }

        }
        else
        {
            int random = Mathf.Abs(Random.Range(0, spawnNodes.Count - 1));
            if (sNode == null)
            {
                index = random;
                sNode = spawnNodes[index];
                papaData.currentDest = sNode.transform.position;
                papa.agent.SetDestination(papaData.currentDest);
            }
            else
            {
                Vector3 distanceToDest = paparef.transform.position - papaData.currentDest;
                if (distanceToDest.magnitude < 1.5)
                {
                    spawnNodes.RemoveAt(index);
                    sNode = null;
                    
                }
            }
        }

        //spawnPoint = RandomPointInAnnulus(papaData.player.transform.position, papaData.papaMinDespawnDist, papaData.papaMaxDespawnDist);
        //Vector3 distToPlayer = spawnPoint - papaData.player.transform.position;

        //Debug.DrawLine(spawnPoint, papaData.player.transform.up, Color.green, 100f);
        //if (Physics.Raycast(spawnPoint, papaData.player.transform.up, 100f, papaData.occlusionLayers))

        //        spawnPointSet = true;

    }



    //public Vector3 RandomPointInAnnulus(Vector3 origin, float minRadius, float maxRadius)
    //{

    //var randomDirection = (Random.insideUnitCircle * origin).normalized;

    //var randomDistance = Random.Range(minRadius, maxRadius);

    //var point = origin * randomDirection * randomDistance;

    //return point;
    //}
}
