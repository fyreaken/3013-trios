using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSmash : MonoBehaviour
{
    [SerializeField]
    private LightScript lightScript;
    [SerializeField]
    private AudioSource smashSource;
    [SerializeField]
    private AudioSource flickerSource;
    void Start()
    {
        GameEvents.instance.onSmashTrigger += DestroyLight;
    }

    private void DestroyLight()
    {
        lightScript.LightState = LightScript.LightStates.Off;
        smashSource.Play();
        flickerSource.enabled = false;
    }
}
