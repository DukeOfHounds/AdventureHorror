using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FacePlayer : MonoBehaviour
{
    [SerializeField]
    public string looktargetTag = "Main Camera";
    private GameObject lookTarget; // the player or any objects we want to be stared at. 
    private List<Facer> FacingObjects; // list of objects that will stare
    private IEnumerator m_coroutine = null;// coroutine that will eventually cull and rotate objects
    public float rotationSpeed = 10f;
    
    void Awake()// happens after object has been set active
    {
        lookTarget = GameObject.FindWithTag(looktargetTag); // default for testing.
        FacingObjects = new List<Facer>(); // instantiate list
        StartCoroutine(IsActive());
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_coroutine != null) 
            return;
        {
            m_coroutine = IsActive();
            StartCoroutine(m_coroutine);
        }
    }

    public void Register(Facer item)
    {
        FacingObjects.Add(item);
    }

    public void DeRegister(Facer item)
    {
        FacingObjects.Remove(item);
    }

    private IEnumerator IsActive()
    {
        List<Facer> removeList = new List<Facer>();

        if (FacingObjects.Count > 0f)
        {
            foreach (Facer item in FacingObjects)
            {
                if (item.item == null)
                {
                    removeList.Add(item);
                    continue;
                }
               // Debug.Log("you spin me right round baby right round like a construction light");
                item.item.SetActive(Vector3.Distance(lookTarget.transform.position, item.objtrans.position) < item.killDist);// makes sure item is active if close to player
                //Vector3 direction = (-item.objtrans.position + lookTarget.transform.position);// finds direction to look in 
                ////Quaternion lookRotation =  Quaternion.LookRotation(lookTarget.transform.position - item.objtrans.position);
                //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, 0, direction.z));// sets rotation

                //item.objtrans.rotation = Quaternion.SlerpUnclamped(item.objtrans.rotation, lookRotation,  Time.deltaTime*rotationSpeed);// rotates object 
                Vector3 direction = lookTarget.transform.position;


                item.objtrans.LookAt(lookTarget.transform.position);

            }
        }

        yield return null;

        if (removeList.Count > 0f)
        {
            foreach (Facer item in removeList)
            {
                FacingObjects.Remove(item);
            }
        }

        yield return null;

        m_coroutine = null;
    }
}





public class Facer
{
    public GameObject item;
    public Transform objtrans;
    public float killDist;

    public Facer(GameObject item, Transform objtrans, float killDist)
    {
        this.item = item;
        this.objtrans = objtrans;
        this.killDist = killDist;
    }

}