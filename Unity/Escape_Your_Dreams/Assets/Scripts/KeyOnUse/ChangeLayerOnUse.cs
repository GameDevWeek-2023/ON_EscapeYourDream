using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerOnUse : MonoBehaviour
{
    [Tooltip("Only choose one")]
    [SerializeField]
    LayerMask targetLayer;
    [SerializeField]
    GameObject[] toChange;

    private void OnUse()
    {
        foreach(GameObject obj in toChange)
        {
            obj.layer = (int)Mathf.Log(targetLayer, 2);
        }
    }
}
