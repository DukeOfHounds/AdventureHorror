using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public float defaltIntensity = 10;
    public GameObject[] Lights;
    public void Awake()
    {
        Lights = GameObject.FindGameObjectsWithTag("PoweredLight");
        foreach(GameObject light in Lights)
        {
            light.GetComponent<Light>().intensity = defaltIntensity;
        }
    }

    public void changeLightInt(float intensity)
    {
        foreach(GameObject light in Lights)
        {
            light.GetComponent<Light>().intensity = intensity;
        }
    }
}
