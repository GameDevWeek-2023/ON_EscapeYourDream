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
    private LayerMask targetLayer;
    [SerializeField]
    private LayerMask ignoreLayers;
    [SerializeField]
    private float pickupForce = 150f;
    private LayerMask grabbable;
    private LayerMask grabbableConnected;
    private LayerMask grabbed;
    private GameObject target = null;
    private Rigidbody targetRB = null;
    private Transform targetParent = null;
    private Transform realParent = null;
    private bool isDirectChild = true;
    private Vector3 originialLocalPosition = Vector3.zero;
    public static readonly float maxHoldAreaDistance = 2f;
    private LayerMask currentMask = 0;

    private void Start()
    {
        grabbable = LayerMask.GetMask("Grabbable");
        grabbed = LayerMask.GetMask("Grabbed");
        grabbableConnected = LayerMask.GetMask("GrabbableConnected");
    }
    private void OnGrab()
    {
        if(target == null)
        {
            RaycastHit hit;
            if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * maxHoldAreaDistance, out hit) && ((targetLayer & (1 << hit.transform.gameObject.layer)) > 0))
            {
                target = hit.transform.gameObject;
                if(grabbableConnected == (grabbableConnected | 1 << hit.transform.gameObject.layer))
                {
                    GrabbableConnectedParent grabParent;
                    if (target.TryGetComponent<GrabbableConnectedParent>(out grabParent))
                    {
                        targetParent = grabParent.ConnectingParent;
                        isDirectChild = grabParent.IsDirectChild;
                        originialLocalPosition = target.transform.localPosition;
                        realParent = target.transform.parent;
                    }
                    else
                    {
                        targetParent = target.transform.parent;
                    }
                    currentMask = grabbableConnected;
                }
                else
                {
                    targetParent = target.transform.parent;
                    currentMask = grabbable;
                }
                target.transform.parent = holdArea;
                targetRB = target.GetComponent<Rigidbody>();
                targetRB.isKinematic = false;
                targetRB.useGravity = false;
                targetRB.drag = 10;
                targetRB.freezeRotation = true;
                target.transform.gameObject.layer = (int)Mathf.Log(grabbed.value, 2);
            }
        }
        else
        {
            dropObject();
        }
    }

    public void dropObject()
    {
        if(target != null)
        {
            if (currentMask == grabbableConnected)
            {
                foreach (Transform child in targetParent.GetComponentsInChildren<Transform>())
                {
                    if ( child.parent != targetParent)
                    {
                        continue;
                    }
                    child.position = (child.position.y - child.position.y % 100) * Vector3.up + target.transform.position - (target.transform.position.y - target.transform.position.y % 100) * Vector3.up;
                }
            }
            target.transform.parent = targetParent;
            if (!isDirectChild)
            {
                target.transform.parent = realParent;
                target.transform.localPosition = originialLocalPosition;
            }
            target.transform.gameObject.layer = (int)Mathf.Log(currentMask.value, 2);
            targetRB.freezeRotation = false;
            targetRB.useGravity = true;
            targetRB.drag = 1;
            target.SendMessage("GetDropped", SendMessageOptions.DontRequireReceiver);
            target = null;
            targetRB = null;
            isDirectChild = true;
        }  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * maxHoldAreaDistance, out hit, ignoreLayers))
        {
            holdArea.position = hit.point + hit.normal*0.1f;
        }
        else
        {
            holdArea.position = cameraTransform.position + cameraTransform.forward * maxHoldAreaDistance;
        }

        if(target != null)
        {
            if (Vector3.Distance(holdArea.position, target.transform.position) > 0.1f)
            {
                Vector3 moveDirection = holdArea.position - target.transform.position;
                targetRB.AddForce(moveDirection * pickupForce);
            }
        }
    }
}
