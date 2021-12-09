using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    [Header("Settings")]
    public float defaltIntensity = 10;
    [Range(0,200)]
    public float currentIntesity = 0;
    private float setIntensity;
    public Texture Ilumination;
    public Texture noIlumination;

    public GameObject[] Lights;

    private void Update()
    {
        if (currentIntesity != 0 && currentIntesity != setIntensity)
        {
            setIntensity = currentIntesity;
            changeLightInt(currentIntesity);
        }
    }
    public void Awake()
    {
        setIntensity = defaltIntensity;
        currentIntesity = defaltIntensity;
        Lights = GameObject.FindGameObjectsWithTag("PoweredLight");
        changeLightInt(defaltIntensity);
    }

    public void changeLightInt(float intensity)
    {
        foreach(GameObject light in Lights)
        {
            light.GetComponent<Light>().intensity = intensity;
            if (intensity == 0)
            {
                light.GetComponent<Material>().mainTexture = noIlumination;
            }
            else
            {
                light.GetComponent<Material>().mainTexture = Ilumination;
            }
        }
    }

    public void PowerOff()
    {
        changeLightInt(0);
    }
    public void PowerOn()
    {
        changeLightInt(currentIntesity);
    }
}
