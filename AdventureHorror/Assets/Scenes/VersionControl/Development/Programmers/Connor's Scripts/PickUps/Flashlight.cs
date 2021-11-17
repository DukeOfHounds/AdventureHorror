using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light light;
    public float lightIntensity;
    public AudioManager audioManager;
    public void Use()
    {
        Sound s = Array.Find(audioManager.sounds, sound => sound.name == "flash_on_1");

        //Debug.Log(lightIntensity);
        if (light.intensity == 0) // if flashlight is off
        {

            light.intensity = lightIntensity;// turns flashlight on
            if (!s.source.isPlaying)
                audioManager.Play("flash_on_1");

        }
        else // if flashlight is on
        {
            light.intensity = 0; // turns flashlight off
            if (!s.source.isPlaying)
                audioManager.Play("flash_off_1");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        light = gameObject.GetComponentInChildren<Light>();
        if (lightIntensity == 0)
            lightIntensity = light.intensity; // finds default intensity
        light.intensity = 0; // turns off flashlight at start
    }
}
