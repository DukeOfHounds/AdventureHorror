using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnData sD;
    public List<GameObject> beds;
    public List<GameObject> tables;
    public List<GameObject> spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        sD.sM = this;
        StartCoroutine(Initialize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomizeLists()
    {
        int index = Random.Range(0, beds.Count - 1);
        spawnLocations.Add(beds[index]);
        index = Random.Range(0, tables.Count - 1);
        spawnLocations.Add(tables[index]);
        foreach (GameObject i in spawnLocations)
        {
            Instantiate(i.GetComponent<RandomSpawner>().friend, i.transform.position, i.transform.rotation);
            Debug.Log(i);
        }
    }

    IEnumerator Initialize()
    {
        yield return new WaitForSeconds(1f);
        RandomizeLists();
    }
}
