using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private GameObject Facer = null;
    public float killDist = 1000f;
    private FacePlayer fScript = null;



    private void Awake()
    {
        Facer = GameObject.Find("RotationManager");
        fScript = Facer.GetComponent<FacePlayer>();
    }

    private void Start()
    {
        // Use a public method to add to the list, rather than making it public:
        fScript.Register(new Facer(this.gameObject, this.transform, this.killDist));


    }

}


