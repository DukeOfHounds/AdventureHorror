using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Movement
{
    public PapaData papaData;
    public Papa papa;
    private GameObject paparef;
    private GameObject cSNode;
    private int index;
    private bool searching = false;

    public enum State
    { StartSearch, Search, Chase, Despawn }

    public State currentState;
    private List<GameObject> searchNodes = new List<GameObject>();
    Collider[] colliders = new Collider[10];

    int count;

    public PP_Movement(PapaData papaData, Papa papa)
    {
        this.papaData = papaData;
        this.papa = papa;
        this.paparef = papaData.Papa;

    }

    
    public void HandleMovement()
    {
       
        Debug.Log(papa.pD.player.gameObject.transform.position);
        if (papaData.canSeeTarget)
        {
            currentState = State.Chase;
        }

        switch (currentState)
        {
            case State.StartSearch:
                StartSearch();
                break;

            case State.Search:
                Search();
                break;

            case State.Chase:
                Chase();
                break;

            case State.Despawn:
                Despawn();
                break;
        }       
    }

    private void StartSearch()
    {
        papa.agent.speed = papaData.papaBaseSpeed;
        papaData.currentDest = papa.pD.player.gameObject.transform.position;
        Vector3 distanceToDest = papa.pD.player.gameObject.transform.position - papaData.currentDest;
        papa.agent.SetDestination(papaData.currentDest);
        if (distanceToDest.magnitude < 20f)
        {
            currentState = State.Search;
            //papa.StopMovement(2f);
        }

    }

    private void Search()
    {
        if (searchNodes.Count == 0)
        {
            searching = true;
            papa.agent.speed = papaData.papaBaseSpeed;
            count = Physics.OverlapSphereNonAlloc(paparef.transform.position, 30f, colliders, papaData.searchNodeLayer, QueryTriggerInteraction.Collide);
            for (int i = 0; i < count; ++i)
            {
                if (papaData.canSeeTarget)
                {
                    break;
                }
                else
                {
                    GameObject obj = colliders[i++].gameObject;

                    Vector3 distanceToDest = paparef.transform.position - obj.transform.position;
                    if (distanceToDest.magnitude > 3)
                    {
                        searchNodes.Add(obj);
                    }
                }

            }

        }
        else
        {
            int random = Mathf.Abs(Random.Range(0, searchNodes.Count -1));
        if (cSNode == null)
            {
                papaData.timesSearched = papaData.timesSearched + 1;
                index = random;
                cSNode = searchNodes[index];
                papaData.currentDest = cSNode.transform.position;
                papa.agent.SetDestination(papaData.currentDest);
            }
            else
            {
                Vector3 distanceToDest = paparef.transform.position - papaData.currentDest;
                if (distanceToDest.magnitude < 1.5)
                {
                    searchNodes.RemoveAt(index);
                    cSNode = null;
                    papa.StopMovement(2f);
                }
            }
        }
        

        //currentState = State.Despawn;
    }

    private void Chase()
    {

        papaData.currentDest = papaData.targetLastSeen;
        Vector3 distanceToPlayer = paparef.transform.position - papa.pD.player.gameObject.transform.position;
        if(!papaData.canSeeTarget)
        {
            
        }
        if (distanceToPlayer.magnitude < 3)
        {
            //if(playerIsHiding)
            {
                //if(sawPlayerHiding)
                {

                }
            }
        }
        else
        {
            if(papa.agent.velocity.magnitude < 1)
            {
                if (distanceToPlayer.magnitude < 15)
                {
                    papaData.currentDest = papa.pD.player.transform.position;
                }
                else
                {
                    currentState = State.StartSearch;
                    papa.StopMovement(2f);
                }
            }

            papa.agent.SetDestination(papaData.currentDest);
            papa.agent.speed = papaData.papaBaseSpeed * papaData.chaseSpeedMultiplier;
        }
    }

    private void Despawn()
    {
        papaData.despawning = true;
        papa.agent.speed = papaData.papaBaseSpeed;
        float distanceToPlayer = Vector3.Distance(papa.agent.transform.position, papa.pD.player.gameObject.transform.position);
        Vector3 directionOfTarget = (papa.pD.player.gameObject.transform.position - papa.agent.transform.position).normalized;
        if ((distanceToPlayer > 30f) && (!Physics.Raycast(papa.agent.transform.position, directionOfTarget, distanceToPlayer, papaData.occlusionLayers)))
        {
            papaData.isActive = false;
            paparef.transform.position = papaData.timeOut;
            papaData.despawning = false;

        }



    }






}
