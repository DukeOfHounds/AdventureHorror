using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMain : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject obj = GameObject.Find("Main Camera");
    private SpinTowards SpinTo;

    // Update is called once per frame
    void Start()
    {
        SpinTo.Target = obj.transform.position;
    }
}
