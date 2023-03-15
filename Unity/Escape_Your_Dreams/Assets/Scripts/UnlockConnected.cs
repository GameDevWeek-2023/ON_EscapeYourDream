using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockConnected : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> connectedLocks;
    private void UnlockOther()
    {
        foreach(GameObject other in connectedLocks)
        {
            other.SendMessage("Unlock", SendMessageOptions.DontRequireReceiver);
        }
    }
}
