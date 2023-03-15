using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPortal : MonoBehaviour
{
    [SerializeField]
    private Transform otherMirror;
    private GrabObject objectGrabber;
    private Transform holdArea;

    private void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        objectGrabber = player.GetComponent<GrabObject>();
        holdArea = player.GetChild(0).GetChild(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent == holdArea)
        {
            objectGrabber.dropObject();
            other.transform.position = otherMirror.position + otherMirror.forward * 0.5f;
            other.SendMessage("Reflect", SendMessageOptions.DontRequireReceiver);
        }
    }
}
