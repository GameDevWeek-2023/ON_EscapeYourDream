using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerChange : MonoBehaviour
{
    [SerializeField]
    bool sleep = true;
    [SerializeField]
    private Image whiteFade;
    private readonly int minLayer = 1;
    private readonly int maxLayer = 4;
    private static int currentLayer = 1;
    private static bool fading = false;
    bool fade = false;
    float fadeSpeed = 0.015f;
    float fadeDirection = 1;
    float currentAlpha = 0;
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
        if (sleep && currentLayer < maxLayer && !fading)
        {
            fade = true;
            fading = true;
        }
        else if(!sleep && currentLayer > minLayer && !fading)
        {
            fade = true;
            fading = true;
        }
    }
    private void FixedUpdate()
    {
        if (fade)
        {
            currentAlpha += fadeSpeed * fadeDirection;
            if (currentAlpha >= 1)
            {
                objectGrabber.dropObject();
                if (sleep)
                {
                    player.SetPositionAndRotation(new Vector3(-4.374f, player.position.y + 100, 2.401f), Quaternion.Euler(0, 180, 0));
                    currentLayer++;
                }
                else
                {
                    player.SetPositionAndRotation(new Vector3(-4.374f, player.position.y - 100, 2.401f), Quaternion.Euler(0, 180, 0));
                    currentLayer--;
                }
                
                fadeDirection = -1;
            }
            if (currentAlpha <= 0)
            {
                fadeDirection = 1;
                fade = false;
                fading = false;
            }
            Mathf.Clamp(currentAlpha, 0, 1);
            Color tempColor = whiteFade.color;
            tempColor.a = currentAlpha;
            whiteFade.color = tempColor;
        }
    }
}
