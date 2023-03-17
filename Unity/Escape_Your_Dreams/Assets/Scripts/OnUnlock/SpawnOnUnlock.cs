using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnUnlock : MonoBehaviour
{
    [Tooltip("All should have the same length")]
    [SerializeField]
    GameObject[] toSpawn;
    [SerializeField]
    Vector3[] positions;
    [SerializeField]
    Vector3[] rotations;
    [SerializeField]
    Transform[] parents;

    private void Unlock()
    {
        for(int i = 0; i<toSpawn.Length; i++){
            Instantiate(toSpawn[i], positions[i], Quaternion.Euler(rotations[i]), parents[i]);
        }
    }
}
