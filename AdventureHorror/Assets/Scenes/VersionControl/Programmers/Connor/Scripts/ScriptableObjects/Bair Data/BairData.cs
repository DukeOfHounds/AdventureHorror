using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BairData", menuName = "BairData/Generic")]


public class BairData : ScriptableObject
{
    [SerializeField]
    [Header("Bair Stuff")]
    public GameObject Bair; // should be the prefab associated with this Bair
    public GameObject BairHeart; // should be the prefab associate with this Bair's heart

    [SerializeField]
    [Header("Buff Stuff")]
    public ScriptableObject BuffData;// what the buff is/does
}
