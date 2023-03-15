using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflectable : MonoBehaviour
{
    [SerializeField]
    GameObject ReflectedVersion;
    private void Reflect()
    {
        Instantiate(ReflectedVersion, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
