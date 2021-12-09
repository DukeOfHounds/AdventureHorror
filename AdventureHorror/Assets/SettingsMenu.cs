using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public PlayerData pD;
    public Slider slider;

    private void Start()
    {
        slider.value = pD.mouseSensitivity;
        SetSensitivity();
    }

    private Vector2Int[] resolutions = 
    {
        new Vector2Int(640, 480),
        new Vector2Int(1920, 1080),
        new Vector2Int(2560, 1440)
    };

    public void SetSensitivity()
    {
        Debug.Log("sensitivity is: " + slider.value);
        pD.mouseSensitivity = slider.value;   
    }

    public void SetResolution(int index)
    {
        Vector2Int desiredResolution = resolutions[index];
        Screen.SetResolution(desiredResolution.x, desiredResolution.y, true);
    }
}
