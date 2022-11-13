using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    private float distance = 2f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitinfo;
        if(Physics.Raycast(ray, out hitinfo, distance, mask))
        {
            if (hitinfo.collider.GetComponent<Interactable>()!=null)
            {
                Interactable interactable = hitinfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    interactable.BaseInteract(); 
                }
            }
        }
    }
}
