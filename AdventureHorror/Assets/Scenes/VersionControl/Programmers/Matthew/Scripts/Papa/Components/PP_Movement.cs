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
    public Vector3 currentDest;

    public enum State
    { StartSearch, Search, Chase, Despawn }

    public State currentState;
    private List<GameObject> searchNodes = new List<GameObject>();
    Collider[] colliders = new Collider[10];

    int count = 69;

    public PP_Movement(PapaData papaData, Papa papa)
    {
        this.papaData = papaData;
        this.papa = papa;
        this.paparef = papaData.Papa;

    }

    
    public void HandleMovement()
    {

        Debug.Log(papaData.canSeeTarget);
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
        currentDest = papaData.player.transform.position;
        Vector3 distanceToDest = paparef.transform.position - currentDest;
        if (distanceToDest.magnitude < 20f)
        {
            currentState = State.Search;
            papa.StopMovement(2f);
        }
        papa.agent.SetDestination(currentDest);

    }

    private void Search()
    {
        Debug.Log(cSNode);
        if (searchNodes.Count == 0)
        {
            searching = true;
            papa.agent.speed = papaData.papaBaseSpeed;
            count = Physics.OverlapSphereNonAlloc(paparef.transform.position, 30f, colliders, papaData.searchNodeLayer, QueryTriggerInteraction.Collide);
            Debug.Log(count);
            for (int i = 0; i < count; ++i)
            {
                    
                GameObject obj = colliders[i++].gameObject;
                
                Vector3 distanceToDest = paparef.transform.position - obj.transform.position;
                if (distanceToDest.magnitude > 3)
                {
                    searchNodes.Add(obj);
                }


            }

        }
        else
        {
            Debug.Log(searchNodes.Count);
            int random = Mathf.Abs(Random.Range(0, searchNodes.Count -1));
        if (cSNode == null)
            {
                index = random;
                Debug.Log(index);
                cSNode = searchNodes[index];
                currentDest = cSNode.transform.position;
                papa.agent.SetDestination(currentDest);
            }
            else
            {
                Vector3 distanceToDest = paparef.transform.position - currentDest;
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

        currentDest = papaData.targetLastSeen;
        Vector3 distanceToDest = paparef.transform.position - currentDest;
        Vector3 distanceToPlayer = paparef.transform.position - papaData.player.transform.position;
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
                currentState = State.StartSearch;
                papa.StopMovement(2f);
            }

            papa.agent.SetDestination(currentDest);
            papa.agent.speed = papaData.papaBaseSpeed * papaData.chaseSpeedMultiplier;
        }
    }

    private void Despawn()
    {
        papa.agent.speed = papaData.papaBaseSpeed;
    }

}
