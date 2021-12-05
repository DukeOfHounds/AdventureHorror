using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDistortian : MonoBehaviour
{
    [SerializeField]
    [Header("Sources")]
    public GameObject papa;
    public GameObject player;
    public AudioSource audio;
    [SerializeField]
    [Header("Variables")]
    [Range(0, 1)]
    public int volumeMultiplier = 0;
    // Start is called before the first frame update
    void Start()
    {

        papa = GameObject.FindGameObjectWithTag("Papa");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(papa.transform.position, player.transform.position);
        RaycastHit hit;// holds data on what is infront of the player
        Debug.DrawRay(papa.transform.position, player.transform.position);
        Physics.Raycast(ray, out hit);// finds what is infront of the player
        if (hit.collider != null && hit.collider.gameObject == player)
        {
            audio.volume *= volumeMultiplier;
        }
    }
}
