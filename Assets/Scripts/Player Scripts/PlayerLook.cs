using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private Transform m_PlayerBody;
  
     public float mouseSensitivity = 100.0f;
     public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    private float playerRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerRotation += mouseY;

        playerRotation = Mathf.Clamp(playerRotation, -clampAngle, clampAngle);

        //rotY = Mathf.Clamp(rotY, -clampAngle, clampAngle); // could be used to limit the player viewpoint

        transform.localRotation = Quaternion.Euler(playerRotation, 0f, 0f);
        m_PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
