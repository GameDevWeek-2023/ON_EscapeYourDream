using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableConnectedParent : MonoBehaviour
{
    [SerializeField]
    private Transform connectingParent;
    [SerializeField]
    private bool isDirectChild = true;
    public Transform ConnectingParent
    {
        get => connectingParent;
    }
    public bool IsDirectChild
    {
        get => isDirectChild;
    }
}
