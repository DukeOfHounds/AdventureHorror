using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light light;
    public float lightIntensity;
    public void Use()
    {
        //Debug.Log(lightIntensity);
        if (light.intensity == 0)
        {
            light.intensity = lightIntensity;// turns flashlight on
        }
        else
        {
            light.intensity = 0; // turns flashlight off
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponentInChildren<Light>();
        if (lightIntensity == 0)
            lightIntensity = light.intensity; // finds default intensity
        light.intensity = 0; // turns off flashlight at start
    }
}
