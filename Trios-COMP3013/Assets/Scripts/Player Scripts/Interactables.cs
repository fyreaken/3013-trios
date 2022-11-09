using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    public string gameMessage;
    public void BaseInteract()
    {
        interact();
    }
    protected virtual void interact()
    {
        //its supposed to be empty so it can be used as a template function for the sub-objects
    }
}
