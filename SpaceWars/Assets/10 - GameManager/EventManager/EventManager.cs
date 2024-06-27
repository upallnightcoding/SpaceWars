using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager 
{
    public event Action<float> OnUpdateAmmo = delegate { };
    public event Action<float> OnReloadAmmo = delegate { };

    public void InvokeOnUpdateAmmo(float fraction) => OnUpdateAmmo.Invoke(fraction);
    public void InvokeOnReloadAmmo(float fraction) => OnReloadAmmo.Invoke(fraction);

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
