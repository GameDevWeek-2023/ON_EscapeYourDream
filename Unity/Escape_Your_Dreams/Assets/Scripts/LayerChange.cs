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
    public int Layer
    {
        get => currentLayer;
    }
    private Transform player;
    private GrabObject objectGrabber;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        objectGrabber = player.GetComponent<GrabObject>();
    }
    private void Interacted()
    {
        if (sleep && currentLayer < maxLayer)
        {
            objectGrabber.dropObject();
            currentLayer++;
            player.position += Vector3.up * 100;
        }
        else if(!sleep && currentLayer > minLayer)
        {
            objectGrabber.dropObject();
            currentLayer--;
            player.position += Vector3.up * -100;
        }
    }
}
