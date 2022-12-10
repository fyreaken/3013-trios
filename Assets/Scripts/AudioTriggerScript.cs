using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
    public AudioSource audioSource;
    private bool alreadyPlayed = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !audioSource.isPlaying && !alreadyPlayed)
        {
            GameEvents.instance.soundEffectTrigger();
        }
    }

    private void Start()
    {
        GameEvents.instance.onSoundEffectTrigger += EnterSoundTrigger;
    }

    private void EnterSoundTrigger()
    {
        audioSource.Play();
        alreadyPlayed = true;
    }
}
