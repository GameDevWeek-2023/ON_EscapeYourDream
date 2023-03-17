using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeKinematicOnUse : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    private void OnUse()
    {
        rb.isKinematic = true;
    }
}
