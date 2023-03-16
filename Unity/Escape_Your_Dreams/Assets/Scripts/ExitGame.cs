using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void OnExitGame()
    {
        Debug.Log("Test");
        Application.Quit();
    }
}
