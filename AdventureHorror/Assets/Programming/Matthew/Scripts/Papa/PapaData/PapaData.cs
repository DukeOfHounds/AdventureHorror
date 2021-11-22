using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PapaData", menuName = "PapaData/Generic")]
public class PapaData : ScriptableObject
{

    [Header("Papa")]
    public GameObject Papa; //Papa object
    public Vector3 targetLastSeen;
    public bool isActive = false;
    public Vector3 timeOut;
    public bool despawning;
    public Vector3 spawnPoint = Vector3.zero;



    [Header("Sight Variables")]
    [Range(0, 360)]
    public float angle;
    [Range(0, 5)]
    public float catchRange = 3;
    public bool canSeeTarget;
    public bool isAgro = false;
    public float radius;

    [HideInInspector]
    public LayerMask targetLayer;
    public LayerMask occlusionLayers;
    public Vector3 adjustCone;
    

    [Header("Movement")]
    [Range(0,12)]
    public float papaBaseSpeed = 3.5f;
    [Range(0,5)]
    public float chaseSpeedMultiplier = 2f;
    public int timesSearched = 0;
    public LayerMask searchNodeLayer;
    public LayerMask spawnNodeLayer;
    public float papaMinDespawnDist;
    public float papaMaxDespawnDist;
    public Vector3 currentDest;


}
