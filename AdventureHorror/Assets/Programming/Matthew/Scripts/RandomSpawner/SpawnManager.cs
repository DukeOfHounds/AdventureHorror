using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnData sD;
    public List SpawnData
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        
    }

    IEnumerator Initialize()
    {
        yield return new WaitForSeconds(.02f);
        Spawn();
    }
}
