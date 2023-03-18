using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject InGame;
    public GameObject InPause;
    private bool Paused;

    private void Start()
    {
        Paused = false;
    }


    public void CloseGame()
    {
        Application.Quit();
    }

    public void EndPause()
    {
        InGame.SetActive(true);
        InPause.SetActive(false);
        GetComponent<GrabObject>().enabled = true;
        GetComponent<Tooltips>().enabled = true;
        GetComponent<Interact>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<RotateCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().fieldOfView = PlayerPrefs.GetInt("FOV", 60);
        // GetComponent<RotateCamera>().MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 0.1f);
        
    }

    private void StartPause()
    {
        InGame.SetActive(false);
        InPause.SetActive(true);
        GetComponent<GrabObject>().enabled = false;
        GetComponent<Tooltips>().enabled = false;
        GetComponent<Interact>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<RotateCamera>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnPauseGame()
    {
        if (Paused)
        {
            EndPause();
            Paused = false;
        }
        else
        {
            StartPause();
            Paused = true;
        }
    }
}
