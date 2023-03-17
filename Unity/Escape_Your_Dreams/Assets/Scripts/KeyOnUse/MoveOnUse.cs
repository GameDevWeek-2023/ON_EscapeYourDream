using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnUse : MonoBehaviour
{
    [SerializeField]
    private Transform[] toMove;
    [SerializeField]
    private Transform[] targets;

    private void OnUse()
    {
        for(int i = 0; i< targets.Length; i++)
        {
            toMove[i].SetPositionAndRotation(targets[i].position, targets[i].rotation);
        }
    }
}
