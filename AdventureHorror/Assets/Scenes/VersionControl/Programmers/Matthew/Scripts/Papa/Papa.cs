using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Papa : MonoBehaviour
{

    public PapaData ppD;
    public PP_LOS los;
    public PP_Movement ppM;
    public NavMeshAgent agent;
    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        //ppD = ScriptableObject.CreateInstance<PapaData>();
        ppD.Papa = gameObject;
        los = new PP_LOS(ppD, this);
        ppM = new PP_Movement(ppD, this);
        ppM.currentState = PP_Movement.State.StartSearch;
    }

    // Update is called once per frame
    void Update()
    {
        if (ppD.isActive)
        {
            los.LineOfSightCheck();
            ppM.HandleMovement();
        }
    }

    //Stops movement along navMesh for "wait" seconds
    public void StopMovement(float wait)
    {
        StartCoroutine(SM(wait));
    }
    public IEnumerator SM(float wait)
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(wait);
        agent.isStopped = false;
    }

    public void Refresh()
    {
        //ppD = ScriptableObject.CreateInstance<PapaData>();
        ppD.Papa = gameObject;
        los = new PP_LOS(ppD, this);
        ppM = new PP_Movement(ppD, this);
        ppM.currentState = PP_Movement.State.StartSearch;
    }

}
