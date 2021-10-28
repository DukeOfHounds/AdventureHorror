using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Overwatch : MonoBehaviour
{

    public PapaData ppD;
    public Papa ppS;
    public PO_Overwatch oW;
    public GameObject papaPref;

    // Start is called before the first frame update
    void Awake()
    {
        //ppD = ScriptableObject.CreateInstance<PapaData>();
        Instantiate(papaPref);
        ppS = papaPref.GetComponent<Papa>();
        ppD.Papa = papaPref;
        oW = new PO_Overwatch(ppD, ppS, this);
        ppD.isActive = false;
    }


    void Update()
    {
        FearCheck();
    }
    private void FearCheck()
    {

        //Debug.Log(oW.papa.ppM);
        if (ppD.isActive)
        {
            if (ppD.despawning)
                oW.GetLocation();
        }
        else
        {
            //if(fear >= threshhold)
            //{
                oW.GetLocation();
            //}
        }

    }

}
