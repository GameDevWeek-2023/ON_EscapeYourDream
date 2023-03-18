using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public object notOptoion;
    public object theOption;
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

    }

    public void CloseOptions()
    {

    }

}
