using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltips : MonoBehaviour
{
    [SerializeField]
    private Transform TooltipContainer;
    [SerializeField]
    private Transform cameraTransform;
    LayerMask grabbable;
    LayerMask interactable;
    private Transform grabTooltip;
    private Transform interactTooltip;

    private void Start()
    {
        grabbable = LayerMask.GetMask("Grabbable");
        interactable = LayerMask.GetMask("Interactable");
        grabTooltip = TooltipContainer.GetChild(0);
        interactTooltip = TooltipContainer.GetChild(1);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * GrabObject.maxHoldAreaDistance, out hit) && grabbable == (grabbable | (1 << hit.transform.gameObject.layer)))
        {
            grabTooltip.localScale = Vector3.one;
        }
        else
        {
            grabTooltip.localScale = Vector3.zero;
        }
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * 2f, out hit) && grabbable == (grabbable | (1 << hit.transform.gameObject.layer)))
        {
            grabTooltip.localScale = Vector3.one;
        }
        else
        {
            grabTooltip.localScale = Vector3.zero;
        }
    }
}
