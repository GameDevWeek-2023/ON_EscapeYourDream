using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObject : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Transform holdArea;
    [SerializeField]
    private LayerMask targetLayers;
    [SerializeField]
    private LayerMask ignoreLayers;
    [SerializeField]
    private float pickupForce = 150f;
    private GameObject target = null;
    private Rigidbody targetRB = null;
    private Transform targetParent = null;
    private Vector3 originalTargetPosition = Vector3.zero;
    
    private void OnGrab()
    {
        if(target == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 2.5f, targetLayers))
            {
                target = hit.transform.gameObject;
                originalTargetPosition = hit.transform.position;
                targetParent = target.transform.parent;
                target.transform.parent = holdArea;
                targetRB = target.GetComponent<Rigidbody>();
                targetRB.useGravity = false;
                targetRB.drag = 10;
                targetRB.freezeRotation = true;
            }
        }
        else
        {
            bool skip = true;
            foreach(Transform child in targetParent.GetComponentsInChildren<Transform>())
            {
                if (skip)
                {
                    skip = false;
                    continue;
                }
                child.SetPositionAndRotation(child.position.y * Vector3.up + target.transform.position - originalTargetPosition.y * Vector3.up, target.transform.rotation);
            }
            target.transform.parent = targetParent;
            targetRB.freezeRotation = false;
            targetRB.useGravity = true;
            targetRB.drag = 1;
            target = null;
            targetRB = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            if(Vector3.Distance(holdArea.position, target.transform.position) > 0.1f)
            {
                Vector3 moveDirection = holdArea.position - target.transform.position;
                targetRB.AddForce(moveDirection * pickupForce);
            }
        }
    }
}
