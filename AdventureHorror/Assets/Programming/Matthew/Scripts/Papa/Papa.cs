using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Papa : MonoBehaviour
{

    public PapaData ppD;
    public PlayerData pD;
    public PP_LOS los;
    public PP_Movement ppM;
    public NavMeshAgent agent;
    public Animator animator;
    public bool waiting;

    public Collider hitbox;


    // Start is called before the first frame update
    void Awake()
    {
        //ppD = ScriptableObject.CreateInstance<PapaData>();
        ppD.Papa = gameObject;
        ppD.timesSearched = 0;
        los = new PP_LOS(ppD, this);
        ppM = new PP_Movement(ppD, this);
        ppM.currentState = PP_Movement.State.StartSearch;
        //ppD.isActive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(ppM.currentState);
        if (ppD.isActive)
        {
            los.LineOfSightCheck();
            ppM.HandleMovement();
            animator.SetFloat("speed", agent.velocity.magnitude/4);
            if (ppD.timesSearched > 10)
            {
                //ppM.currentState = PP_Movement.State.Despawn;
            }
        }
    }

    //Stops movement along navMesh for "wait" seconds
    public void StopMovement(float wait)
    {
        animator.SetTrigger("stop");
        waiting = true;
        StartCoroutine(SM(wait));
        waiting = false;
    }

    public void AnimationTrigger(float wait, string anim)
    {
        animator.SetTrigger(anim);
        waiting = true;
        StartCoroutine(SM(wait));
        waiting = false;
    }


    public IEnumerator SM(float wait)
    {
        agent.isStopped = true;
        while (ppD.canSeeTarget && ppM.currentState != PP_Movement.State.Chase)
        {
            animator.enabled = false;
            animator.enabled = true;
            agent.isStopped = false;
            yield break;
        }
        yield return new WaitForSeconds(wait);
        agent.isStopped = false;
    }

    public void Refresh()
    {
        //ppD = ScriptableObject.CreateInstance<PapaData>();
        ppD.Papa = gameObject;
        //los = new PP_LOS(ppD, this);
        //ppM = new PP_Movement(ppD, this);
        ppM.currentState = PP_Movement.State.StartSearch;
    }

    public void TeleportPapa(Vector3 spawnPoint)
    {

        agent.Warp(spawnPoint);
        //Debug.Log("Teleport wooosh wooosh wooosh");
        //Debug.Log(spawnPoint);
    }



}
