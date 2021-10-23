using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papa : MonoBehaviour
{

    private PapaData ppD;
    private PP_VisionCheck ppVc;
    // Start is called before the first frame update
    void Awake()
    {
        ppVc = new PP_VisionCheck(ppD, this);
    }

    // Update is called once per frame
    void Update()
    {
        ppVc.HandleScanning();
    }
}
