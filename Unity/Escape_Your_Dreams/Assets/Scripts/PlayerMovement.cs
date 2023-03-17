using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 move = Vector2.zero;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float jumpForce = 4;
    [SerializeField]
    private float ladderSpeed = 0.1f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    private float extraFallForce = 0.05f;
    private bool quickFall = true;
    Rigidbody rb;
    private bool ladder = false;
    private float jumpState;
    public bool UsingLadder
    {
        get => ladder;
        set => ladder = value;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnJump(InputValue value)
    {
        jumpState = value.Get<float>();
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
        if (jumpState >= 1)
        {
            if (ladder)
            {
                rb.MovePosition(transform.position + transform.up * ladderSpeed);
            }
            else
            {
                if (isGrounded())
                {
                    quickFall = false;
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                }
                else if (rb.velocity.y < 0.2f || quickFall)
                {
                    quickFall = true;
                    rb.velocity += Physics.gravity * extraFallForce;
                }
                velocity.y = rb.velocity.y;
            }
        }
        else
        {
            if (ladder)
            {
                velocity.y = 0;
                rb.MovePosition(transform.position - transform.up * ladderSpeed);
            }
            else
            {
                quickFall = true;
                rb.velocity += Physics.gravity * extraFallForce;
                velocity.y = rb.velocity.y;
            }
        }
        rb.velocity = velocity;
    }

    private bool isGrounded()
    {
        return Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hit, 0.6f, groundLayer);
    }
}
