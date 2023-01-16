using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{

    [SerializeField]
    private Inventory playerInventory;
    protected override void Interact()
    {
        playerInventory.InventoryItems.Add("key");
        gameObject.SetActive(false);
    }
}
