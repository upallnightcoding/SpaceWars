using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
public class InputCntrl : MonoBehaviour
{
    public Vector2 Move { get; set; }
    public bool Fire { get; set; }
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log($"OnMove Performed: {context.ReadValue<Vector2>()}");
            Move = context.ReadValue<Vector2>();
        }

        if (context.canceled)
        {
            Move = Vector2.zero;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            Fire = false;
        }

        if (context.started)
        {
            Fire = true;
        }

      
    }
}
