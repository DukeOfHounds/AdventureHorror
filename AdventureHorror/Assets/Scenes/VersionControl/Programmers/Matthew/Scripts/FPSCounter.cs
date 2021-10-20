using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public float fps;
    public Text fpsCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        fpsCounter.text = fps + "FRAMES";
        Debug.Log(fps + "FRAMES");
    }
}
