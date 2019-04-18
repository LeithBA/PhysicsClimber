using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour {

	//AUTO DESTROYS OBJECT THAT FALL OUT OF BOUND
	void Update () 
	{
		if (this.transform.position.y <= -5)
			Destroy(this.gameObject);
	}
}
