using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public PlayerData pD;
    public Slider slider;
    public void SetSensitivity()
    {
        Debug.Log("sensitivity is: " + slider.value);
        pD.mouseSensitivity = slider.value;   
    }
}
