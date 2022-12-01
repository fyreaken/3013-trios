using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip openClip;
    [SerializeField]
    private AudioClip closeClip;

    private bool doorClosed = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        doorClosed = !doorClosed;
        if (doorClosed)
        {
            source.PlayOneShot(closeClip);
        }
        else
        {
            source.PlayOneShot(openClip);
        }
        door.GetComponent<Animator>().SetBool("Closed", doorClosed);
    }
}