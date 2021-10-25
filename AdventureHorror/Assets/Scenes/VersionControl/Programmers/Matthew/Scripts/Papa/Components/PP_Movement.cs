using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Movement
{
    public PapaData papaData;
    public Papa papa;
    private GameObject paparef;
    public bool searching = false;

    public PP_Movement(PapaData papaData, Papa papa)
    {
        this.papaData = papaData;
        this.papa = papa;
        this.paparef = papaData.Papa;
    }

    public void HandleMovement()
    {
        if (!searching)
        {
            papa.agent.SetDestination(papaData.targetLastSeen);
        }
        else
            SearchPattern();

    }
    private void SearchPattern()
    {
        searching = true;
    }
}
