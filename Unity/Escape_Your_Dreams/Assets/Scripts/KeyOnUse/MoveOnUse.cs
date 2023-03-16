using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnUse : MonoBehaviour
{
    [SerializeField]
    private Transform targetLocation;
    [SerializeField]
    private Transform[] toMove;

    private void OnUse()
    {
        foreach(Transform obj in toMove)
        {
            obj.SetLocalPositionAndRotation(targetLocation.position, targetLocation.rotation);
        }
    }
}
