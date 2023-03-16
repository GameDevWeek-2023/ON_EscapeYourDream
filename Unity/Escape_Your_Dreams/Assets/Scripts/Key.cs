using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int lockID;
    private GrabObject objectGrabber;

    private void Start()
    {
        objectGrabber = GameObject.FindGameObjectWithTag("Player").GetComponent<GrabObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Unlockable Lock;
        if(other.gameObject.TryGetComponent<Unlockable>(out Lock) && Lock.lockNumber == lockID)
        {
            objectGrabber.dropObject();
            other.gameObject.SendMessage("Unlock", SendMessageOptions.DontRequireReceiver);
            other.gameObject.SendMessage("UnlockOther", SendMessageOptions.DontRequireReceiver);
            gameObject.SendMessage("OnUse", SendMessageOptions.DontRequireReceiver);
        }
    }
}
