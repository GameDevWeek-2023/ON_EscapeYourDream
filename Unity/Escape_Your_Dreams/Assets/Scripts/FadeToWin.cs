using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToWin : MonoBehaviour
{
    [SerializeField]
    private Transform winMessage;
    [SerializeField]
    private Image whiteFade;
    [SerializeField]
    private Transform player;
    bool fade = false;
    float fadeSpeed = 0.0075f;
    float fadeDirection = 1;
    float currentAlpha = 0;

    private void Interacted()
    {
        fade = true;
    }

    private void FixedUpdate()
    {
        if (fade)
        {
            currentAlpha += fadeSpeed * fadeDirection;
            if (currentAlpha >= 1)
            {
                winMessage.localScale = Vector3.one;
                player.SetPositionAndRotation(new Vector3(-4.374f, 401.1f, 2.401f), Quaternion.Euler(0, 180, 0));
                fadeDirection = -1;
            }
            if (currentAlpha <= 0)
            {
                fadeDirection = 1;
                fade = false;
            }
            Mathf.Clamp(currentAlpha, 0, 1);
            Color tempColor = whiteFade.color;
            tempColor.a = currentAlpha;
            whiteFade.color = tempColor;
        }
    }
}
