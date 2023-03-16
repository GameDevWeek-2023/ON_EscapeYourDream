using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnUse : MonoBehaviour
{
    [SerializeField]
    private GameObject[] toDestroy;
    [SerializeField]
    private bool needFinalDestroy = true;
    [SerializeField]
    private GameObject finalDestroy;
    private void OnUse()
    {
        foreach (GameObject connected in toDestroy)
        {
            Destroy(connected);
        }
        if(needFinalDestroy)
            Destroy(finalDestroy);
    }
}
