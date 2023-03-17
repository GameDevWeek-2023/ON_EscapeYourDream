using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnUse : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;
    private void OnUse()
    {
        foreach(GameObject target in targets)
        {
            target.SetActive(true);
        }
    }
}
