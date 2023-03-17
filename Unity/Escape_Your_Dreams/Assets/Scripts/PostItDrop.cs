using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostItDrop : MonoBehaviour
{
    private LayerMask ignoreLayers;
    private Rigidbody rb;
    [SerializeField]
    private bool isConnected = true;
    private void Start()
    {
        ignoreLayers = LayerMask.GetMask("Grabbable", "GrabbableConnected", "Player", "Grabbed", "Interactable");
        rb = gameObject.GetComponent<Rigidbody>();
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
        if(isConnected)
            UpdateConnectedPosition();
    }

    private void UpdateConnectedPosition()
    {
        Transform[] PostIts = transform.parent.GetComponentsInChildren<Transform>();
        for(int i = 1; i<4; i++)
        {
            PostIts[i].SetPositionAndRotation((PostIts[i].position.y - PostIts[i].position.y % 100) * Vector3.up + transform.position, transform.rotation);
        }
    }
}
