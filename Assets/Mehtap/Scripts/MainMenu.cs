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

    public Button invert;

    //These are for Loading other Scenes
    public string newGameSceneName;
    public string creditScene;
    public string backtoMenue;

    GameState GS;
    InvertMatCol IMC;

    public Text[] texts;

    /*---------------------------MenueFunctions------------------------------*/

    void Start()
    {
        GS = GameObject.Find("GameManager").GetComponent<GameState>();
        IMC = GameObject.Find("GameManager").GetComponent<InvertMatCol>();
    }

    public void NewGame()
    {
        GS.SetState(GS.inGame);
        SceneManager.LoadScene("GameScene");
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

    public void Invert()
    {
        Debug.Log("Click");
        if (IMC.dark == true)
        {
            Camera.main.backgroundColor = IMC.bgLight;
            for (int i = 0; i < GameObject.Find("MenuManager").GetComponent<MainMenu>().texts.Length; i++)
            {
                GameObject.Find("MenuManager").GetComponent<MainMenu>().texts[i].color = IMC.objDark;
            }
        }

        else if (IMC.dark == false)
        {
            Camera.main.backgroundColor = IMC.bgDark;
            for (int i = 0; i < GameObject.Find("MenuManager").GetComponent<MainMenu>().texts.Length; i++)
            {
                GameObject.Find("MenuManager").GetComponent<MainMenu>().texts[i].color = IMC.objLight;

            }
        }
    }
}
