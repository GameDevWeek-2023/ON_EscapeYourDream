using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    [SerializeField]
    bool sleep = true;
    private readonly int minLayer = 1;
    private readonly int maxLayer = 4;
    private static int currentLayer = 1;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Interacted()
    {
        if (sleep && currentLayer < maxLayer)
        {
            currentLayer++;
            player.position += Vector3.up * 100;
        }
        else if(!sleep && currentLayer > minLayer)
        {
            currentLayer--;
            player.position += Vector3.up * -100;
        }
    }
}
