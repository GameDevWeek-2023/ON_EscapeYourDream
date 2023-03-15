using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostItPortal : MonoBehaviour
{
    [SerializeField]
    private Transform otherPortal;
    private Transform player;
    private GrabObject objectGrabber;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        objectGrabber = player.GetComponent<GrabObject>();
    }
    private void Interacted()
    {
        float verticalOffset = 0;
        float horizontalOffset = 0;

        if (Physics.Linecast(otherPortal.position + otherPortal.forward * 0.1f, otherPortal.position + otherPortal.forward * 0.1f + otherPortal.right * -0.5f)){
            horizontalOffset += 0.5f;
        }
        if (Physics.Linecast(otherPortal.position + otherPortal.forward * 0.1f, otherPortal.position + otherPortal.forward * 0.1f + otherPortal.right * 0.5f))
        {
            horizontalOffset += -0.5f;
        }
        if (Physics.Linecast(otherPortal.position + otherPortal.forward * 0.1f, otherPortal.position + otherPortal.forward * 0.1f + otherPortal.up * -0.5f))
        {
            verticalOffset += 1f;
        }
        if (Physics.Linecast(otherPortal.position + otherPortal.forward * 0.1f, otherPortal.position + otherPortal.forward * 0.1f + otherPortal.up * 0.5f))
        {
            verticalOffset += -1f;
        }
        objectGrabber.dropObject();
        player.position = otherPortal.position + otherPortal.forward * 0.5f + otherPortal.up * verticalOffset + otherPortal.right * horizontalOffset;
    }
}
