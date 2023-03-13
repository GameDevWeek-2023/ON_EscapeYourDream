using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 move = Vector2.zero;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float jumpForce = 1;
    [SerializeField]
    LayerMask groundLayer;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnJump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 right = transform.right * move.x;
        Vector3 forward = transform.forward * move.y;
        Vector3 moveDir = (right + forward).normalized;
        Vector3 velocity = speed * moveDir;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    private bool isGrounded()
    {
        return Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hit, 1.0f, groundLayer);
    }
}
