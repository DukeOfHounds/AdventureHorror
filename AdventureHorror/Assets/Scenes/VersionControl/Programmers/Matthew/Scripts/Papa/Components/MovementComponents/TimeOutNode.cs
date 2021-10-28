using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutNode : MonoBehaviour
{
    public MeshRenderer r;
    private PapaData papaData;
    // Start is called before the first frame update
    void Start()
    {
        papaData = (PapaData)FindObjectOfType(typeof(PapaData));
        papaData.timeOut = gameObject.transform.position;
    }

    // Update is called once per frame

}
