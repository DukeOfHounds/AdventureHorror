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
        los.LineOfSightCheck();
        ppM.HandleMovement();
    }

}
