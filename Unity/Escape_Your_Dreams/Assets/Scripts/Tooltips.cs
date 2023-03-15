using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltips : MonoBehaviour
{
    [SerializeField]
    private Transform TooltipContainer;
    [SerializeField]
    private Transform cameraTransform;
    private LayerMask grabbed;
    private LayerMask grabbable;
    private LayerMask interactable;
    private Transform grabTooltip;
    private Transform interactTooltip;
    private TMP_Text interactText;

    private void Start()
    {
        grabbable = LayerMask.GetMask("Grabbable", "GrabbableConnected");
        interactable = LayerMask.GetMask("Interactable");
        grabbed = LayerMask.GetMask("Grabbed");
        grabTooltip = TooltipContainer.GetChild(0);
        interactTooltip = TooltipContainer.GetChild(1);
        interactText = interactTooltip.GetComponentInChildren<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * GrabObject.maxHoldAreaDistance, out hit) && (grabbable & (1 << hit.transform.gameObject.layer)) > 0)
        {
            grabTooltip.localScale = Vector3.one;
        }
        else
        {
            grabTooltip.localScale = Vector3.zero;
        }
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * 2f, out hit, ~grabbed) && interactable == (interactable | (1 << hit.transform.gameObject.layer)))
        {
            interactTooltip.localScale = Vector3.one;
            interactText.text = hit.transform.GetComponent<Interactable>().interactText;
        }
        else
        {
            interactTooltip.localScale = Vector3.zero;
        }
    }
}
