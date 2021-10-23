using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PapaData", menuName = "PapaData/Generic")]
public class PapaData : ScriptableObject
{

    [Header("Papa")]
    public GameObject Papa; //Papa object

    [Header("Sight Variables")]
    public float distance;
    public float angle;
    public float height;
    public Color wedgeColor;
    public int scanFrequency;
    public LayerMask layers;
    public LayerMask occlusionLayers;

}
