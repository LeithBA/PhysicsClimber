﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertMatCol : MonoBehaviour
{

    public bool dark;
    [SerializeField] public Color32 envDark, envLight, objDark, objLight, bgDark, bgLight;

    public void Invert()
    {
        dark = !dark; // Tap was here~

        /*if (dark == true)
        {
            //MAKE LIGHT
            dark = false;
        }

        if (dark == false) // Should be else if here
        {
            //MAKE DARK
            dark = true;
        }*/
    }


    public void InvertStuff()
    {
        if (dark == true)
        {
            Camera.main.backgroundColor = bgLight;
            for (int i = 0; i < GameObject.Find("MenuManager").GetComponent<MainMenu>().texts.Length; i++)
            {
                GameObject.Find("MenuManager").GetComponent<MainMenu>().texts[i].color = objDark;

            }
        }

        else if (dark == false)
        {

            Camera.main.backgroundColor = bgDark;
            for (int i = 0; i < GameObject.Find("MenuManager").GetComponent<MainMenu>().texts.Length; i++)
            {
                GameObject.Find("MenuManager").GetComponent<MainMenu>().texts[i].color = objLight;

            }
         
        }
        Invert();
        Debug.Log(dark);
    }
}
