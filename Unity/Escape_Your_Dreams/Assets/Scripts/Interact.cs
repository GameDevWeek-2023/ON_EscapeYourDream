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
    private LayerMask grabbed;
    private void Start()
    {
        grabbed = LayerMask.GetMask("Grabbed");
    }
    private void OnInteract()
    {
        RaycastHit hit;
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * maxInteractionDistance, out hit, ~grabbed) && targetLayer == (targetLayer | (1 << hit.transform.gameObject.layer)))
        {
            GameObject target = hit.transform.gameObject;
            target.SendMessage("Interacted");
        }
    }
}
