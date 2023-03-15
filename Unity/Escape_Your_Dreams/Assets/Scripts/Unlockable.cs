using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    [SerializeField]
    private int lockID;
    public int lockNumber
    {
        get => lockID;
    }
}
