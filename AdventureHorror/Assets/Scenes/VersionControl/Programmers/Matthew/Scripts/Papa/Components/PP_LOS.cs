using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_LOS
{
    //Scriptable Object Variables 
    public PapaData papaData;
    public Papa papa;

    private GameObject paparef; 

    //Constructor
    public PP_LOS(PapaData papaData, Papa papa)
    {
        this.papaData = papaData;
        this.papa = papa;
        this.paparef = papaData.Papa;
    }
    //Running on Cooroutine instead of update

    //Main Method
    public void LineOfSightCheck()
    {
        Debug.Log(papaData.canSeeTarget);
        //Array of Colliders (within line of sight) only of the layer specified in targetLayer
        Collider[] rangeChecks = Physics.OverlapSphere(paparef.transform.position, papaData.radius, papaData.targetLayer);
        //If collider is in the array, find angle from front of Papa, to the player (presumably).
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionOfTarget = (target.position - paparef.transform.position).normalized;

            //Check if the angle is outside of Papa's sight cone.
            if (Vector3.Angle(paparef.transform.position, directionOfTarget) < papaData.angle / 2)//Reduce size of cone by half to do more detailed angle check.
            {
                float distanceToTarget = Vector3.Distance(paparef.transform.position, target.position);

                if (!Physics.Raycast(paparef.transform.position, directionOfTarget, distanceToTarget, papaData.occlusionLayers))
                {
                    papaData.targetLastSeen = target.position;
                    papaData.canSeeTarget = true;
                }
                else
                    papaData.canSeeTarget = false; 
            }
            else
                papaData.canSeeTarget = false;
        }
        else if (papaData.canSeeTarget)
            papaData.canSeeTarget = false;
    }

}
