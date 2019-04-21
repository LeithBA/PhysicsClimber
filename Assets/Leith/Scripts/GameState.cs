using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

		SetState(inMenu);
    }
    [HideInInspector] public bool inMenu, inGame, dead;

	public void SetState(bool state)
	{
		inMenu = false;
		inGame = false;
		dead = false;

		state = true;
	}
}
