using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    bool locked = false;
    bool closed = true;
    bool moving = false;
    private Transform parentTransform;
    private float rotationSpeed = 5;
    float minOpen = -90;
    float maxClosed = 0;
    float currentRotation = 0;

    private void Start()
    {
        parentTransform = transform.parent;
    }
    private void Unlock()
    {
        locked = false;
    }
    private void Interacted()
    {
        if(!locked && closed && !moving)
        {
            closed = false;
            moving = true;
        }
        else if (!locked && !closed && !moving)
        {
            closed = true;
            moving = true;
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            float oldRotation = currentRotation;
            int rotationDirection;
            if (closed)
            {
                rotationDirection = 1;
            }
            else
            {
                rotationDirection = -1;
            }
            currentRotation += rotationSpeed * rotationDirection;

            if (currentRotation > maxClosed || currentRotation < minOpen)
            {
                moving = false;
            }
            currentRotation = Mathf.Clamp(currentRotation, minOpen, maxClosed);
            parentTransform.localRotation *= Quaternion.Euler(0, currentRotation - oldRotation, 0);
        }
    }
}
