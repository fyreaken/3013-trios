using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSmashTrigger : MonoBehaviour
{
    private bool alreadyPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !alreadyPlayed)
        {
            alreadyPlayed = true;
            GameEvents.instance.SmashLight();
        }
    }
}
