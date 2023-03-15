using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int lockID;
    private void OnTriggerEnter(Collider other)
    {
        Unlockable Lock;
        if(other.gameObject.TryGetComponent<Unlockable>(out Lock) && Lock.lockNumber == lockID)
        {
            other.gameObject.SendMessage("Unlock", SendMessageOptions.DontRequireReceiver);
            other.gameObject.SendMessage("UnlockOther", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
