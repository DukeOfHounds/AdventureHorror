using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCollision : MonoBehaviour
{
    private Papa papa;
    // Start is called before the first frame update
    void Start()
    {
        papa = transform.root.gameObject.GetComponent<Papa>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision obj)
    {
        if ((obj.collider.tag.Equals("PickUpAble") || obj.collider.tag.Equals("Friend")) && ! papa.waiting)
        {
            papa.StopMovement(2);//
        }
    }
}
