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

           
            if (!s.source.isPlaying)
                audioManager.Play("flash_on_1");
           // light.intensity = lightIntensity;
            StartCoroutine(LightIntensity(lightIntensity));// turns flashlight on

        }
        else // if flashlight is on
        {
            if (!s.source.isPlaying)
                audioManager.Play("flash_off_1");
            StartCoroutine(LightIntensity(0));// turns flashlight off

            //light.intensity = ; // turns flashlight off

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

    IEnumerator LightIntensity( float intensity)
    {
        yield return new  WaitForSeconds(.5f);
        light.intensity = intensity;
    }
}
