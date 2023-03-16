using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int lockID;
    [SerializeField]
    private bool destroyOnUnlock = true;
    [SerializeField]
    private GameObject toDestroy;
    private void OnTriggerEnter(Collider other)
    {
        Unlockable Lock;
        if(other.gameObject.TryGetComponent<Unlockable>(out Lock) && Lock.lockNumber == lockID)
        {
            other.gameObject.SendMessage("Unlock", SendMessageOptions.DontRequireReceiver);
            other.gameObject.SendMessage("UnlockOther", SendMessageOptions.DontRequireReceiver);
            if(destroyOnUnlock)
                Destroy(toDestroy);
        }
    }
}
