using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipmentcontainer : MonoBehaviour
{
    public float pushforce = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Rigidbody _rigidbody = hit.collider.attachedRigidbody;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_rigidbody != null)
            {
                Vector3 forcedirection = hit.gameObject.transform.position - transform.position;
                forcedirection.y = 0;
                forcedirection.Normalize();

                _rigidbody.AddForceAtPosition(forcedirection * pushforce, transform.position, ForceMode.Impulse);
            }
        }

    }

}
