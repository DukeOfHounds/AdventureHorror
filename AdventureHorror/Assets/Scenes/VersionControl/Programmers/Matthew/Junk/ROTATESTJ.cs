using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTATEST : MonoBehaviour
{
    private GameObject lookTarget;
    // Start is called before the first frame update
    void Awake()
    {
        lookTarget = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(lookTarget.transform.position.x, this.transform.position.y, lookTarget.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
