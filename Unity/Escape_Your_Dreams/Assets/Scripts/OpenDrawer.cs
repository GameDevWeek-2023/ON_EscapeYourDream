using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    enum Direction
    {
        openTowardsX = 1,
        openAwayFromX = -1
    }
    [SerializeField]
    bool locked = false;
    bool closed = true;
    bool moving = false;
    [SerializeField]
    float openingSpeed = 5;
    float closedDistance = 0;
    [SerializeField]
    float openDistance = 1;
    float currentDistance = 0;
    [SerializeField]
    private Direction openDirection = Direction.openTowardsX;
    private Interactable Tooltip;
    private Vector3 originalPosition;
    private Rigidbody rb;

    private void Start()
    {
        Tooltip = gameObject.GetComponent<Interactable>();
        originalPosition = transform.position;
        rb = transform.GetComponent<Rigidbody>();
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
            int moveDirection;
            if (closed)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = 1;
            }
            currentDistance += openingSpeed * moveDirection;

            if (currentDistance >openDistance || currentDistance < closedDistance)
            {
                moving = false;
            }
            currentDistance = Mathf.Clamp(currentDistance, closedDistance, openDistance);
            rb.MovePosition(originalPosition + currentDistance * (int)openDirection * transform.right);
        }
    }
}
