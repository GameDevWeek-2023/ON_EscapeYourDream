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
    private Transform grabTooltip;

    private void Start()
    {
        grabbable = LayerMask.GetMask("Grabbable");
        grabTooltip = TooltipContainer.GetChild(0);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(cameraTransform.position, cameraTransform.position + cameraTransform.forward * 2.5f, out hit) && grabbable == (grabbable | (1 << hit.transform.gameObject.layer)))
        {
            grabTooltip.localScale = Vector3.one;
        }
        else
        {
            grabTooltip.localScale = Vector3.zero;
        }
    }
}
