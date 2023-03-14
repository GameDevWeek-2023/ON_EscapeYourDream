using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObject : MonoBehaviour
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
    
    private void onGrab()
    {
        if(target == null)
        {
            Debug.Log("Grab");
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position + cameraTransform.forward*5, cameraTransform.forward, out hit, targetLayers))
            {
                Debug.Log("FoundGrab");
                target = hit.transform.gameObject;
                targetRB = target.GetComponent<Rigidbody>();
                targetRB.isKinematic = true;
                targetRB.freezeRotation = true;
            }
        }
        else
        {
            Debug.Log("Let Go");
            targetRB.freezeRotation = false;
            targetRB.isKinematic = false;
            target = null;
            targetRB = null;
        }
    }

    private void OnDrawGizmos()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            target.transform.position = cameraTransform.position + pickupDistance * cameraTransform.forward;
        }
    }
}
