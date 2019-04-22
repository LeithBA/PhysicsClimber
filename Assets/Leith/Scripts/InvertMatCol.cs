using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertMatCol : MonoBehaviour
{

    public bool dark;
    [SerializeField] public Color32 envDark, envLight, objDark, objLight, bgDark, bgLight;
    [SerializeField] GameObject menuManager;
    GameState GS;

    private void Start()
    {
        GS = GameObject.Find("GameManager").GetComponent<GameState>();
    }

    private void Update()
    {
        
            if (menuManager == null && GS.inMenu == true)
                menuManager = GameObject.Find("MenuManager");
    }

    public void Invert()
    {
        dark = !dark;
    }


    public void InvertMenu()
    {
        if (GS.inMenu == true)
        {
            if (dark == true)
            {
                Camera.main.backgroundColor = bgLight;
                for (int i = 0; i < menuManager.GetComponent<MainMenu>().texts.Length; i++)
                {
                    menuManager.GetComponent<MainMenu>().texts[i].color = objLight;
                }
                menuManager.GetComponent<MainMenu>().invertButton.image.color = envLight;
                menuManager.GetComponent<MainMenu>().muteButton.image.color = envLight;
            }

            else if (dark == false)
            {

                Camera.main.backgroundColor = bgDark;
                for (int i = 0; i < menuManager.GetComponent<MainMenu>().texts.Length; i++)
                {
                    menuManager.GetComponent<MainMenu>().texts[i].color = objDark;

                }
                menuManager.GetComponent<MainMenu>().invertButton.image.color = envDark;
                menuManager.GetComponent<MainMenu>().muteButton.image.color = envDark;

            }
        }
    }
}
