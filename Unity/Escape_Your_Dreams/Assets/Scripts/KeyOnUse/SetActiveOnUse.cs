using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnUse : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;
    [SerializeField]
    private bool[] states;
    private void OnUse()
    {
        for(int i = 0; i<targets.Length; i++)
        {
            targets[i].SetActive(states[i]);
        }
    }
}
