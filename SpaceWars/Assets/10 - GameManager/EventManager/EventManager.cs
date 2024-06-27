using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager 
{
    public event Action<float> OnUpdateAmmo = delegate { };

    public void InvokeOnUpdateAmmo(float percentage) => OnUpdateAmmo.Invoke(percentage);

    public static EventManager Instance
    {
        get
        {
            if (aInstance == null)
            {
                aInstance = new EventManager();
            }

            return (aInstance);
        }
    }

    public static EventManager aInstance = null;
}
