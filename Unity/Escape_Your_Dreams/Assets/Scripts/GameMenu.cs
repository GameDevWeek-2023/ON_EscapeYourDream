using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject Uno;
    public GameObject Duo;
    public GameObject Tres;
    public GameObject Quattro;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        Tres.SetActive(true);
        Quattro.SetActive(false);
    }

    public void BackToMenu()
    {
        Tres.SetActive(false);
        Quattro.SetActive(true);
    }

    public void Options()
    {
        Uno.SetActive(false);
        Duo.SetActive(true);
    }

    public void CloseOptions()
    {
        Uno.SetActive(true);
        Duo.SetActive(false);
    }

}
