using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpawner : MonoBehaviour {

	float timer = 0;
	[SerializeField] float lavaPeriod;
	[SerializeField] GameObject lava;

	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= lavaPeriod)
		{
			timer = 0;
			lavaInit();
		}
	}

	private void lavaInit()
	{
		Instantiate(lava, gameObject.transform.position, Quaternion.identity);
	}
}
