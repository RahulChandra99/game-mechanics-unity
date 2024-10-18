using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewAdventure()
    {
        SceneManager.LoadSceneAsync("Pilot");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
