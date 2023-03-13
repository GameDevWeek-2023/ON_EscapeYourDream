using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    Transform childCamera;
    [SerializeField]
    private float mouseSensitivity = 0.5f;
    private float oldX = 0;
    private float xRotation = 0;
    Vector2 delta;

    private void OnLook(InputValue value)
    {
        delta = value.Get<Vector2>() * mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        oldX = xRotation;
        xRotation = Mathf.Clamp(xRotation - delta.y, -90, 90);
        transform.localRotation *= Quaternion.Euler(0, delta.x, 0);
        childCamera.localRotation *= Quaternion.Euler(xRotation - oldX, 0, 0);

    }
}
