using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_LOS
{
    //Scriptable Object Variables 
    public PapaData papaData;
    public Papa papa;
    private GameObject paparef;
    private bool lostSight = true;
    private float cD = 0f;
    private float timer = 6f;


    //Constructor
    public PP_LOS(PapaData papaData, Papa papa)
    {
        this.papaData = papaData;
        this.papa = papa;
        this.paparef = papaData.Papa;
    }

    void LostSightCheck()
    {
        if (!lostSight)
        {
            if (papa.pD.isHiding && !papaData.sawHiding)
            {

            }
            else
            {
                papaData.targetLastSeen = papa.pD.player.transform.position;
                Vector3 distanceToPlayer = papaData.targetLastSeen - papa.gameObject.transform.position;
                if (cD > 0f)
                {
                    cD = Mathf.Clamp(cD - Time.deltaTime, 0.0f, timer);
                }
                else
                    lostSight = true;
            }
        }
        else
            papaData.canSeeTarget = false;
    }


    //Main Method
    public void LineOfSightCheck()
    {
        //Debug.Log(((int)cD));
        //Array of Colliders (within line of sight) only of the layer specified in targetLayer
        Collider[] rangeChecks = Physics.OverlapSphere(papa.agent.transform.position, papaData.radius, papaData.targetLayer);
        //If collider is in the array, find angle from front of Papa, to the player (presumably).
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionOfTarget = (target.position - papa.agent.transform.position).normalized;

            //Check if the angle is outside of Papa's sight cone.
            if (Vector3.Angle(papa.agent.transform.forward, directionOfTarget) < papaData.angle / 2f)//Reduce size of cone by half to do more detailed angle check.
            {
                float distanceToTarget = Vector3.Distance(papa.agent.transform.position, target.position);
                if (!Physics.Raycast(papa.agent.transform.position, directionOfTarget, distanceToTarget, papaData.occlusionLayers))
                {
                    cD = timer;
                    papaData.targetLastSeen = target.position;
                    papaData.canSeeTarget = true;
                    papaData.isAgro = true;
                    lostSight = false;
                    Debug.Log(papaData.canSeeTarget);
                    Debug.DrawLine(paparef.transform.position, target.position, Color.red, 5f);

                }
                else
                    LostSightCheck();
            }
            else
                LostSightCheck();
        }
        else if (papaData.canSeeTarget)
            LostSightCheck();
    }

}
