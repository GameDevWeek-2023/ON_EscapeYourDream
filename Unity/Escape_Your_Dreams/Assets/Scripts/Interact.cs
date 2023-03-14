using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    public readonly float maxInteractionDistance = 2;
    private LayerMask targetLayer;
    private void OnInteract()
    {
        RaycastHit hit;
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * maxInteractionDistance, out hit) && targetLayer == (targetLayer | (1 << hit.transform.gameObject.layer)))
        {
            target = hit.transform.gameObject;
            originalTargetPosition = hit.transform.position;
            targetParent = target.transform.parent;
            target.transform.parent = holdArea;
            targetRB = target.GetComponent<Rigidbody>();
            targetRB.useGravity = false;
            targetRB.drag = 10;
            targetRB.freezeRotation = true;
            target.transform.gameObject.layer = (int)Mathf.Log(grabbed.value, 2);
        }
    }
}
