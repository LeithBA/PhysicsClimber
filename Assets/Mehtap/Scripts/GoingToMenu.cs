using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoingToMenu : MonoBehaviour
{
    public Button goingBack;
    public string ToMenu; 

    public void GoingBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
