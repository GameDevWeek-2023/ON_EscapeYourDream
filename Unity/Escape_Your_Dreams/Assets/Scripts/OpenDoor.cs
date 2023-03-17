using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    enum Direction
    {
        towardsZ = 1,
        awayFromZ = -1
    }
    [SerializeField]
    bool locked = false;
    [SerializeField]
    Direction direction = Direction.towardsZ;
    bool closed = true;
    bool moving = false;
    private Transform parentTransform;
    private float rotationSpeed = 5;
    float minOpen = -90;
    float maxClosed = 0;
    float currentRotation = 0;
    private Interactable Tooltip;

    private void Start()
    {
        parentTransform = transform.parent;
        Tooltip = gameObject.GetComponent<Interactable>();
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
            Tooltip.interactText = "Close";
        }
        else if (!locked && !closed && !moving)
        {
            closed = true;
            moving = true;
            Tooltip.interactText = "Open";
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
            parentTransform.localRotation *= Quaternion.Euler(0, (currentRotation - oldRotation) * (float)direction, 0);
        }
    }
}
