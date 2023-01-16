using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipmentcontainer : Interactable
{
    public float pushforce = 1;

    private Rigidbody _rigidbody;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        _rigidbody = hit.collider.attachedRigidbody;


       
        if (_rigidbody != null)
        {
            Vector3 forcedirection = hit.gameObject.transform.position - transform.position;
            forcedirection.y = 0;
            forcedirection.Normalize();

            _rigidbody.AddForceAtPosition(forcedirection * pushforce, transform.position, ForceMode.Impulse);
        }

    }


}
