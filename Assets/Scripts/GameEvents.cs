using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        instance = this;
    }
    public event Action onSoundEffectTrigger;
    public void soundEffectTrigger()
    {
        if (onSoundEffectTrigger != null)
        {
            onSoundEffectTrigger.Invoke();
        }

    }

    public event Action onSmashTrigger;
    public void SmashLight()
    {
        if (onSmashTrigger != null)
        {
            onSmashTrigger.Invoke();
        }

    }
}
