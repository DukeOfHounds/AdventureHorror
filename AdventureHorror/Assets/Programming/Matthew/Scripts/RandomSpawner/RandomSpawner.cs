using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public SpawnData sD;
    public SpawnData.spawnType sT;
    public GameObject friend;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Initialize()
    {      
        yield return new WaitForSeconds(.02f);
        switch (sT)
        {
            case SpawnData.spawnType.bed:
                friend = sD.hamster;
                sD.sM.beds.Add(this.gameObject);
                break;

            case SpawnData.spawnType.table:
                friend = sD.snake;
                sD.sM.tables.Add(this.gameObject);
                break;
        }
    }
}
