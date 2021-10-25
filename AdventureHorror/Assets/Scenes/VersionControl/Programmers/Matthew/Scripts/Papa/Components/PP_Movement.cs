using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Movement
{
    public PapaData papaData;
    public Papa papa;
    private GameObject paparef;
    private GameObject cSNode;
    private bool searching;
    public Vector3 currentDest;

    public enum State
    { StartSearch, Search, Chase, Despawn }

    public State currentState;
    private List<GameObject> objects = new List<GameObject>();
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
        if (distanceToDest.magnitude < 20)
        {
            currentState = State.Search;
            //papa.agent.isStopped = true;
        }
        else
        {
            papa.agent.SetDestination(currentDest);
        }
    }

    private void Search()
    {

        if (!searching)
        {
            searching = true;
            papa.agent.speed = papaData.papaBaseSpeed;
            count = Physics.OverlapSphereNonAlloc(paparef.transform.position, 20f, colliders, papaData.searchNodeLayer, QueryTriggerInteraction.Collide);
            for (int i = 0; i < count; ++i)
            {
                    GameObject obj = colliders[i++].gameObject;
                    objects.Add(obj);
            }
            cSNode = objects[random]; 
        }
        else
        {
            Vector3 distanceToDest = paparef.transform.position - currentDest;
            if(distanceToDest.magnitude < 1)
            {

            }
        }
        

        currentState = State.Despawn;
    }

    private void Chase()
    {
        currentDest = papaData.targetLastSeen;
        Vector3 distanceToDest = paparef.transform.position - currentDest;
        if (papa.agent.velocity.magnitude < 1)
        {
            currentState = State.Search;
            //papa.agent.isStopped = true;
        }
        else
        {
            papa.agent.SetDestination(currentDest);
            papa.agent.speed = papaData.papaBaseSpeed * papaData.chaseSpeedMultiplier;
        }
    }

    private void Despawn()
    {
        papa.agent.speed = papaData.papaBaseSpeed;
    }
}
