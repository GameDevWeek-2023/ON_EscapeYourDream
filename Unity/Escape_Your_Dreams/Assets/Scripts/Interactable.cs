using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string text = "Interact";
    public string interactText {
        get => text;
        set => text = value;
    }
}
