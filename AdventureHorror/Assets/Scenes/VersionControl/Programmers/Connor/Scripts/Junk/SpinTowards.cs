using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTowards : MonoBehaviour
{
    public float smoothing = 1f;// speed of spin
    
    public Vector3 Target
    {
        get { return target;  } 
        set
        {
            target = value;

            StopCoroutine("Spin");
            StartCoroutine("Spin", target);
        }
    }

    private Vector3 target;
    IEnumerator Spin(Vector3 target)
    {
        while (Vector3.Angle(gameObject.transform.forward, target) != 0) 
        {
            transform.LookAt(target);
            yield return null;
        }
        
    }
}
