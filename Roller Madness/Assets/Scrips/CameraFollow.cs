using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private float MouseSensitivity;
    public Transform Parent;

    public float SmoothSpeed = 0.125f;
    public Vector3 OffSet;

    void LateUpdate()
    {
        Vector3 DesiredPosition = Target.position + OffSet;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
        transform.position = SmoothedPosition;
        RotateX();
        RotateY();
        //transform.LookAt(Target);
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
