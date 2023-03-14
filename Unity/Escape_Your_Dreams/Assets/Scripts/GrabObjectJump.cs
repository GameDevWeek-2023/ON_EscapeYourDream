using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjectJump : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private LayerMask targetLayers;
    [SerializeField]
    private LayerMask ignoreLayers;
    private float pickupDistance = 5;
    private GameObject target = null;
    private Rigidbody targetRB = null;
    
    private void OnGrab()
    {
        if(target == null)
        {
            Debug.Log("Grab");
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 5, targetLayers))
            {
                Debug.Log("FoundGrab");
                target = hit.transform.gameObject;
                targetRB = target.GetComponent<Rigidbody>();
                targetRB.useGravity = false;
                targetRB.freezeRotation = true;
            }
        }
        else
        {
            Debug.Log("Let Go");
            targetRB.freezeRotation = false;
            targetRB.useGravity = true;
            target = null;
            targetRB = null;
        }
    }

    private void OnDrawGizmos()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            target.transform.position = cameraTransform.position + pickupDistance * cameraTransform.forward;
        }
    }
}
