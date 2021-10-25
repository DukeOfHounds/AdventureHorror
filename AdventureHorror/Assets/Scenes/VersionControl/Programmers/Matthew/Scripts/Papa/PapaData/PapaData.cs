using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PapaData", menuName = "PapaData/Generic")]
public class PapaData : ScriptableObject
{

    [Header("Papa")]
    public GameObject Papa; //Papa object
    public Vector3 targetLastSeen;

    [Header("Sight Variables")]
    
    [Range(0, 360)]
    public float angle;

    public float radius;
    public GameObject player;
    public LayerMask targetLayer;
    public LayerMask occlusionLayers;
    public bool canSeeTarget;


}
