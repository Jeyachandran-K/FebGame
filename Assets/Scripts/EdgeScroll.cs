using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EdgeScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 15;
    [SerializeField]private float edgeSize = 20f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Debug.Log("ScreenWidth : " + Screen.width);
    }
    private void Update()
    {
        
        if(Mouse.current == null)  return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (Cursor.lockState == CursorLockMode.Confined)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 position = transform.position;

        Debug.Log("Mouse position in x : " + mousePosition.x);
        if (mousePosition.x <=edgeSize)
        {
            position.x -= scrollSpeed * Time.deltaTime;
        }

        if (mousePosition.x > edgeSize)
        {
            position.x += scrollSpeed * Time.deltaTime;
        }
        transform.position = position;
    }
}
