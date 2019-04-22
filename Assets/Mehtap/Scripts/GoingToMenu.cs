using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoingToMenu : MonoBehaviour
{
    public Button goingBack;
    public string ToMenu;
    GameState GS;

    private void Start()
    {
        GS = GameObject.Find("GameManager").GetComponent<GameState>();
    }

    public void GoingBack()
    {
        GS.dead = false;
        GS.inMenu = true;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        GS.dead = false;
        GS.inGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
