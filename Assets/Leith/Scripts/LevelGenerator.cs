using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] GameObject level, levelsContainer;
    [SerializeField] GameObject[] objects;
    float nextLevelHeight, wallHeight;
    int currentLevel = 1;

    private void Start()
    {
		wallHeight = level.transform.GetChild(0).localScale.y + 1;
        nextLevelHeight = wallHeight * currentLevel;
    }
    void Update()
    {
        if (this.transform.position.y >= nextLevelHeight - wallHeight)
        {
			GameObject newWall =  Instantiate(level, new Vector3(0, nextLevelHeight, 0), Quaternion.identity, levelsContainer.transform);
			newWall.name = "Level (" + currentLevel + ")";
            currentLevel++;

            GameObject newObject = Instantiate(objects[Random.Range(0, objects.Length)],
                                               newWall.transform.position + new Vector3(Random.Range(-8f, 8f),
                                               Random.Range(-4f, 4f), 0),
                                               Quaternion.identity,
                                               newWall.transform);
            
            float randomScale = Random.Range(1.0f, 3.0f);
            newObject.transform.localScale = new Vector3(randomScale, randomScale, 1);

            newObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            newObject.GetComponent<HingeJoint2D>().connectedBody = null;
            newObject.GetComponent<SpriteRenderer>().color = new Color32(200, 200, 200, 255);
            nextLevelHeight = level.transform.GetChild(0).localScale.y * currentLevel;
			if(currentLevel > 2)
			{
				Destroy(levelsContainer.transform.GetChild(0).gameObject);
			}
        }
    }
}
