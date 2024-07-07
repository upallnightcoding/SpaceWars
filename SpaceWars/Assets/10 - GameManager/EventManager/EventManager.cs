using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager 
{
    // UI/UX Ammo Events
    //==================
    public event Action<float> OnUpdateAmmo = delegate { };
    public event Action<float> OnReloadAmmo = delegate { };

    public void InvokeOnUpdateAmmo(float fraction) => OnUpdateAmmo.Invoke(fraction);
    public void InvokeOnReloadAmmo(float fraction) => OnReloadAmmo.Invoke(fraction);

    // Display Game Play Banners Events
    //=================================
    public event Action OnDisplayYoureDead = delegate { };

    public void InvokeOnDisplayYoureDead() => OnDisplayYoureDead.Invoke();

    // UI/UX Menu Panel Events
    //========================
    public event Action OnDisplayNewGamePanel = delegate { };
    public event Action OnDisplayLoadGamePanel = delegate { };
    public event Action<long> OnUpdateXP = delegate { };

    public void InvokeOnDisplayNewGamePanel() => OnDisplayNewGamePanel.Invoke();
    public void InvokeOnDisplayLoadGamePanel() => OnDisplayLoadGamePanel.Invoke();
    public void InvokeOnUpdateXP(long value) => OnUpdateXP.Invoke(value);

    public event Action<float> OnUpdateFighterHealth = delegate { };

    public void InvokeOnUpdateFighterHealth(float fraction) => OnUpdateFighterHealth.Invoke(fraction);

    public event Action OnDestoryedEnemy = delegate { };
    public void InvokeOnDestoryedEnemy() => OnDestoryedEnemy.Invoke();

    // Event Manager Singleton
    //========================
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
