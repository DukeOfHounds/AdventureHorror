using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject winMenue;
    public Player player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            player.paused = true;
            Instantiate(winMenue);//
        }
    }
}
