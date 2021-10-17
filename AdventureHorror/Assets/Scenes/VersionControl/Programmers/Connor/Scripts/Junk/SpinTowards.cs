using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTowards : MonoBehaviour
{

 //   private GameObject obj = GameObject.Find("Main Camera");

    public float smoothing = 1f;// speed of spin

    private List<Target> targets;
    public Vector3 Target
    {
        get { return target; }
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
        Debug.Log("turning");
        //while (Vector3.Angle(gameObject.transform.forward, target) != 0) 
        //{
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * smoothing);
        yield return null;
        //}

    }
}

public class Target
{
    Vector3 target;
    public Target(Vector3 target)
    {
        this.target = target;
    }

}
