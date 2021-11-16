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
    private bool initialResetWires = true;
    private int timesSearched;
    private float blindsight = 10f;

    public enum State
    { StartSearch, Search, Chase, ResetWires, Respawn, Despawn };

    public State currentState;
    private List<GameObject> searchNodes = new List<GameObject>();
    Collider[] colliders = new Collider[10];

    int count = 0;

    public PP_Movement(PapaData papaData, Papa papa)
    {
        this.papaData = papaData;
        this.papa = papa;
        this.paparef = papaData.Papa;

    }


    public void WireAlert()
    {
        papaData.currentDest = papa.pD.player.transform.position;
        currentState = State.Chase;
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

            case State.ResetWires:
                ResetWires();
                break;

            case State.Respawn:
                Respawn();
                break;

            case State.Despawn:
                Despawn();
                break;
        }
    }
    /// <summary>
    /// This does something... maybe...
    /// </summary>
    private void StartSearch()
    {
        papa.agent.speed = papaData.papaBaseSpeed;
        papaData.currentDest = papa.pD.player.gameObject.transform.position;
        Vector3 distanceToPlayer = papa.pD.player.gameObject.transform.position - papa.gameObject.transform.position;
        papa.agent.SetDestination(papaData.currentDest);
        if (distanceToPlayer.magnitude < 20f)
        {
            currentState = State.Search;
            //papa.StopMovement(2f);
        }

    }

    private void Search()
    {
        if (papa.agent.velocity.magnitude < 1f)
        { 
            papa.agent.SetDestination(papa.pD.player.gameObject.transform.position);
            currentState = State.StartSearch;
        }
        else if (searchNodes.Count == 0 && timesSearched > 0)
        {
            StartSearch();
            timesSearched = 0;
        }
        else if (searchNodes.Count == 0)
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

                    Vector3 distanceToNode = paparef.transform.position - obj.transform.position;
                    if (distanceToNode.magnitude > 3)
                    {
                        searchNodes.Add(obj);
                    }
                }

            }
        }


        else
        {
            int random = Mathf.Abs(Random.Range(0, searchNodes.Count - 1));
            if (cSNode == null)
            {
                ++papaData.timesSearched;
                ++timesSearched;
                index = random;
                cSNode = searchNodes[index];
                papaData.currentDest = cSNode.transform.position;
                papa.agent.SetDestination(papaData.currentDest);
            }
            else
            {
                Vector3 distanceToNode = paparef.transform.position - papaData.currentDest;
                if (distanceToNode.magnitude < 1.5)
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
        if (papaData.canSeeTarget)
            papaData.currentDest = papaData.targetLastSeen;
        Vector3 distanceToPlayer = paparef.transform.position - papa.pD.player.gameObject.transform.position;
        if (!papaData.canSeeTarget)
        {

        }
        if (distanceToPlayer.magnitude < 3)
        {
            TryAttack();
            if(papa.pD.isHiding)
            {
                //if(sawPlayerHiding)
                {

                }
            }
        }
        else
        {
            if (papa.agent.velocity.magnitude < 1f)
            {
                if (distanceToPlayer.magnitude < blindsight)
                {
                    papaData.currentDest = papa.pD.player.transform.position;

                }
                else
                {
                    currentState = State.StartSearch;
                    //papa.StopMovement(2f);
                }
            }

            papa.agent.SetDestination(papaData.currentDest);
            papa.agent.speed = papaData.papaBaseSpeed * papaData.chaseSpeedMultiplier;
        }
    }


    private void ResetWires()
    {

         if (initialResetWires) // handles various start situations when player fails wire puzzle.
        {
            InitialResetWires();
        }
        
        
        // for each wire box
            // if papa sees player 
            // travel to wire box location 
            // fix wire
            

    }

    private void InitialResetWires()
    {
        initialResetWires = false;
        //if papa sees player attack regardless of wire status
        if (papaData.canSeeTarget)
            papaData.currentDest = papaData.targetLastSeen;
        //else TP to a location near player and travel to nearest wire box
    }

    private void Respawn()
    {

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

    private void TryAttack()
    {
        float distanceToPlayer = Vector3.Distance(papa.agent.transform.position, papa.pD.player.gameObject.transform.position);
        Vector3 directionOfTarget = (papa.pD.player.gameObject.transform.position - papa.agent.transform.position).normalized;
        if ((!Physics.Raycast(papa.agent.transform.position, directionOfTarget, distanceToPlayer, papaData.occlusionLayers)))
        {
            papa.pD.player.Death();
        }


    }




}
