using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertMatCol : MonoBehaviour {

	public bool dark;
	[SerializeField] public Color32 envDark, envLight, objDark, objLight, bgDark, bgLight;


	void invert()
	{
		if (dark == true)
		{
			//MAKE LIGHT
			dark = false;
		}

		if (dark == false)
		{
			//MAKE DARK
			dark = true;
		}
	}
}
