using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnUnlock : MonoBehaviour
{
    private void Unlock()
    {
        Destroy(gameObject);
    }
}
