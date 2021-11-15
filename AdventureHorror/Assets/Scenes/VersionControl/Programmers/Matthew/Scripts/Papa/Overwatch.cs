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
    public GameObject timeOut;

    // Stop is called before the first frame update
    void Start()
    {
        //ppD = ScriptableObject.CreateInstance<PapaData>();              
        Instantiate(papaPref, timeOut.transform.position, timeOut.transform.transform.rotation);
        ppS = papaPref.GetComponent<Papa>();
        ppD.Papa = papaPref;
        oW = new PO_Overwatch(ppD, ppS, this);
        ppD.isActive = false;
    }



    void Update()
    {
        Debug.Log(ppD.isActive);
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
            RespawnPapa();

            //}
        }

    }

    public void RespawnPapa()
    {
        oW.GetLocation();
    }
}
