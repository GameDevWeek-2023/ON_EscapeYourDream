using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EisSchmelzen : MonoBehaviour
{
    private bool locked = true;
    [SerializeField]
    private GameObject[] Eisbloecke;
    [SerializeField]
    private GameObject KeyToSpawn;
    private void Unlock()
    {
        locked = false;
    }

    private void Interacted()
    {
        if (!locked)
        {
            locked = true;
            foreach(GameObject eis in Eisbloecke)
            {
                Destroy(eis);
            }
            Instantiate(KeyToSpawn, new Vector3(-4.25f, 1.6f, -3.5f), Quaternion.Euler(0, 0, 0));
        }
    }
}
