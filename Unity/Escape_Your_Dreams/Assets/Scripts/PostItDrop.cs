using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostItDrop : MonoBehaviour
{
    private LayerMask ignoreLayers;
    private Rigidbody rb;
    private Collider trigger;
    private void Start()
    {
        ignoreLayers = LayerMask.GetMask("Grabbable", "GrabbableConnected", "Player", "Grabbed", "Interactable");
        rb = gameObject.GetComponent<Rigidbody>();
        trigger = gameObject.GetComponent<SphereCollider>();
    }
    private void GetDropped()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.03f, transform.forward, out hit, 0.3f, ~ignoreLayers)){
            ClingToWall(hit);
        }
        else if (Physics.SphereCast(transform.position, 0.03f, -transform.forward, out hit, 0.3f, ~ignoreLayers))
        {
            ClingToWall(hit);
        }
    }

    private void ClingToWall(RaycastHit hit)
    {
        rb.isKinematic = true;
        transform.forward = hit.normal;
        transform.position = hit.point + transform.forward * 0.005f;
        UpdateConnectedPosition();
    }

    private void UpdateConnectedPosition()
    {
        int skip = 2;
        foreach (Transform child in transform.parent.GetComponentsInChildren<Transform>())
        {
            if (skip > 0)
            {
                skip--;
                continue;
            }
            child.SetPositionAndRotation((child.position.y - child.position.y % 100) * Vector3.up + transform.position, transform.rotation);
        }
    }
}
