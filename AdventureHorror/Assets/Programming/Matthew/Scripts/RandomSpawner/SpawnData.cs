using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "SpawnData/Generic")]

public class SpawnData : ScriptableObject
{
    public enum spawnType { bed, table };
    public SpawnManager sM;
    public GameObject hamster;
    public GameObject snake;
}
