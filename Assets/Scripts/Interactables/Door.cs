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
    [SerializeField]
    private AudioClip unlockClip;

    private bool doorClosed = true;

    public bool Locked = false;

    public Inventory playerInventory;

    void OnEnable()
    {
        if (Locked)
        {
            promptMessage = "You need a key to unlock this.";
        }
    }

    protected override void Interact()
    {
        if (Locked)
        {
            if (playerInventory.InventoryItems.Contains("key"))
            {
                Locked = false;
                promptMessage = "[F]";
                source.PlayOneShot(unlockClip);
            }
            else
            {
                return;
            }
        }
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