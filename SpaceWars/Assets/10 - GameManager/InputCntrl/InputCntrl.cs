using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
public class InputCntrl : MonoBehaviour
{
    public Vector2 Move { get; private set; } = Vector2.zero;
    public Vector2 Look { get; private set; } = Vector2.zero;

    public bool Fire { get; private set; }
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // WASD Keys or Controller Left Stick
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Move = context.ReadValue<Vector2>();
        }

        if (context.canceled)
        {
            Move = Vector2.zero;
        }
    }

    // Left Mouse Button
    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Look = Mouse.current.position.ReadValue();
        }

        if (context.canceled)
        {
            Look = Vector2.zero;
        }
    }

    // Right Mouse Button or Right Trigger Click
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("OnFire ...");
            Fire = true;
        }

        if (context.canceled)
        {
            Fire = false;
        }
    }
}
