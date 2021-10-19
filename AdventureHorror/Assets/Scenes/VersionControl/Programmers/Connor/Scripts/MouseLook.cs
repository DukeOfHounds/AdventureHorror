using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MouseLook : MonoBehaviour
{
    [SerializeField]
    public Transform playerBody;
    
    public  float mouseSensitivity = 100f;

    private float mouseX;
    private float mouseY;

    // Update is called once per frame
    void Update()
    {
        playerBody.Rotate(Vector3.up * mouseX);
    }


    public float GetMouseSensitivity()
    {
        return mouseSensitivity;
    }

    public void SetMouseSensitivity(float newMouseSensitivity)
    {
        mouseSensitivity = newMouseSensitivity;
    }

    #region Input Methods
    public void OnMouseLook(InputAction.CallbackContext context)
    {
        
        mouseX = context.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        mouseY = context.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;
    }

    #endregion
}


