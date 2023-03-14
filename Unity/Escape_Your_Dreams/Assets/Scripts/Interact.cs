using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    public readonly float maxInteractionDistance = 2;
    [SerializeField]
    private LayerMask targetLayer;
    private void OnInteract()
    {
        RaycastHit hit;
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * maxInteractionDistance, out hit) && targetLayer == (targetLayer | (1 << hit.transform.gameObject.layer)))
        {
            GameObject target = hit.transform.gameObject;
            target.SendMessage("Interacted");
        }
    }
}
