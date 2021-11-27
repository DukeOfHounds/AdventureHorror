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
    private GameObject currentWire;
    private bool fixingWires = false;
    

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


    public void WireAlert(GameObject wire)
    {
            currentWire = wire;
            fixingWires = true;
            papaData.currentDest = currentWire.transform.position;
            papa.agent.SetDestination(papaData.currentDest);
            currentState = State.Chase;
    }

    public void HandleMovement()
    {
        //Debug.Log(papaData.sawHiding);
        if (papaData.canSeeTarget)
        {
            currentState = State.Chase;
        }

        if (!papaData.canSeeTarget && fixingWires)
        {
            papaData.currentDest = currentWire.transform.position;
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
        //if (papa.agent.velocity.magnitude < 1f)
        //{ 
        //    papa.agent.SetDestination(papa.pD.player.gameObject.transform.position);
        //    currentState = State.StartSearch;
        //}
        //else if
        if (searchNodes.Count == 0 && timesSearched > 3)
        {
            Debug.Log("Hello1");
            currentState = State.StartSearch;
            timesSearched = 0;
        }
        else if (searchNodes.Count == 0)
        {
            Debug.Log("Hello2");
            searching = true;
            papa.agent.speed = papaData.papaBaseSpeed;
            count = Physics.OverlapSphereNonAlloc(paparef.transform.position, 30f, colliders, papaData.searchNodeLayer, QueryTriggerInteraction.Collide);
            for (int i = 0; i < count; ++i)
            {
                Debug.Log("Hello3");
                if (papaData.canSeeTarget)
                {
                    Debug.Log("Hello4");
                    break;
                }
                else
                {
                    Debug.Log("Hello5");
                    GameObject obj = colliders[i++].gameObject;

                    Vector3 distanceToNode = paparef.transform.position - obj.transform.position;
                    if (distanceToNode.magnitude > 3)
                    {
                        Debug.Log("Hello6");
                        searchNodes.Add(obj);
                    }
                }

            }
        }


        else
        {
            Debug.Log("Hello7");
            int random = Mathf.Abs(Random.Range(0, searchNodes.Count - 1));
            if (cSNode == null)
            {
                Debug.Log("Hello8");
                index = random;
                cSNode = searchNodes[index];
                papaData.currentDest = cSNode.transform.position;
                papa.agent.SetDestination(papaData.currentDest);
            }
            else
            {
                Debug.Log("Hello9");
                Vector3 distanceToNode = papa.agent.transform.position - papaData.currentDest;
                if (distanceToNode.magnitude < 1.5)
                {
                    ++papaData.timesSearched;
                    ++timesSearched;
                    Debug.Log("Hello10");
                    searchNodes.RemoveAt(index);
                    cSNode = null;
                    papa.StopMovement(2f);
                }
                else
                {
                    //Vector3 distanceToPlayer = papa.agent.transform.position - papa.pD.player.gameObject.transform.position;
                    //if (distanceToPlayer.magnitude > 15 && !papaData.canSeeTarget)
                    //{
                    //papaData.currentDest = cSNode.transform.position;
                    //papa.agent.SetDestination(papaData.currentDest);
                    //}
                    //else
                    //{
                    //if (papa.agent.velocity.magnitude < .1 && !papa.waiting)
                    //{
                        
                        //papaData.canSeeTarget = true;
                        //papaData.currentDest = papa.pD.player.gameObject.transform.position;
                        //currentState = State.Chase;
                    //}
                    //}
                }
            }
        }


        //currentState = State.Despawn;
    }

    private void Chase()
    {
        Vector3 distanceToPlayer = paparef.transform.position - papa.pD.player.gameObject.transform.position;
        searchNodes.Clear();
        cSNode = null;
        timesSearched = 0;
        if (papa.pD.isHiding && papaData.sawHiding && distanceToPlayer.magnitude < 10)
        {
            papa.pD.hidingPlace.interactWith(papa.pD);
            TryAttack();

        }
        if (papaData.canSeeTarget)
            papaData.currentDest = papaData.targetLastSeen;
        if (!papaData.canSeeTarget)
        {
            if (fixingWires)
            {
                papaData.currentDest = currentWire.transform.position;
                papa.agent.SetDestination(papaData.currentDest);
                papa.agent.speed = papaData.papaBaseSpeed * papaData.chaseSpeedMultiplier;
                Vector3 distanceToWires = paparef.transform.position - papaData.currentDest;
                if (distanceToWires.magnitude < 3)
                {
                    currentWire.GetComponent<Wire>().ResetWires();
                    fixingWires = false;
                    currentState = State.StartSearch;
                        
                }
            }
            else
            {
                currentState = State.StartSearch;
            }
        }

        if (distanceToPlayer.magnitude < papaData.catchRange)
        {
            if(!papa.pD.isHiding)
                TryAttack();
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
