using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    [SerializeField] GameObject walls, wallContainer;
    float nextLevelHeight, wallHeight;
    int currentLevel = 1;

    private void Start()
    {
		wallHeight = walls.transform.GetChild(0).localScale.y + 1;
        nextLevelHeight = wallHeight * currentLevel;
    }
    void Update()
    {
        Debug.Log(nextLevelHeight + ", " + currentLevel);
        if (this.transform.position.y >= nextLevelHeight - wallHeight)
        {
			GameObject newWall =  Instantiate(walls, new Vector3(0, nextLevelHeight, 0), Quaternion.identity, wallContainer.transform);
			newWall.name = "Level (" + currentLevel + ")";
            currentLevel++;
            nextLevelHeight = walls.transform.GetChild(0).localScale.y * currentLevel;
			if(currentLevel > 2)
			{
				Destroy(wallContainer.transform.GetChild(0).gameObject);
			}
        }
    }
}
