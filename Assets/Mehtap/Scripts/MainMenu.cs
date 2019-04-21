using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    /*-------------------------------Variables-------------------------------*/
    public Button newGameButton;
    public Button creditsButton;
    public Button quitButton;

    //These are for Loading other Scenes
    public string newGameSceneName;
    public string creditScene;
    public string backtoMenue;

    /*---------------------------MenueFunctions------------------------------*/
    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CreditsPlay()
    {
        SceneManager.LoadScene("creditScene");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        // Just to confirm that ExitGame Function is called
        Debug.Log("Exit Game does work, you are just in the Editor :)");

        Application.Quit();
    }
}
