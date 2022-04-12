using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float MouseSensitivity;

    private Transform Parent;

    private void Start()
    {
        Parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RotateX();
        RotateY();

    }

    private void RotateX()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;

        Parent.Rotate(Vector3.up, MouseX);
        
    }

    private void RotateY()
    {
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        Parent.Rotate(Vector3.right, MouseY);
    }
}
