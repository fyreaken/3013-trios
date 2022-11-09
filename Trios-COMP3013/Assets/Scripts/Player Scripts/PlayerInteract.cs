using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 1.5f;
    [SerializeField]
    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitinfo;
       if (Physics.Raycast(ray, out hitinfo, distance, mask))
        {
            if (hitinfo.collider.GetComponent<Interactables>() !=null)
            {
                Debug.Log(hitinfo.collider.GetComponent<Interactables>().gameMessage);
            }
        }

    }
}
