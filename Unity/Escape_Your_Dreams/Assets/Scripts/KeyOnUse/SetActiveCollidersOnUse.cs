using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveCollidersOnUse : MonoBehaviour
{
    [SerializeField]
    Collider[] colliders;
    [SerializeField]
    bool[] states;
    private void OnUse()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = states[i];
        }
    }
}
