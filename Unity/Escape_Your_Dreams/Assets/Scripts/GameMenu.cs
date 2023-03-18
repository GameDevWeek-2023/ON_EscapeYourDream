using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject Uno;
    public GameObject Duo;

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
        SceneManager.LoadScene("Credits");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartingScreen");
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
