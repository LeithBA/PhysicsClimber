using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] GameObject level, levelsContainer;
    [SerializeField] GameObject[] objects;
    float nextLevelHeight, wallHeight;
    int currentLevel = 1;

    InvertMatCol IMC;

    private void Start()
    {
        wallHeight = level.transform.GetChild(0).localScale.y + 1;
        nextLevelHeight = wallHeight * currentLevel;
        IMC = GameObject.Find("GameManager").GetComponent<InvertMatCol>();

        if (IMC.dark == true)
        {
            for (int i = 0; i < GameObject.Find("Level (0)").transform.childCount; i++)
            {
                GameObject.Find("Level (0)").transform.GetChild(i).GetComponent<SpriteRenderer>().color = IMC.envDark;

            }
            Camera.main.backgroundColor = IMC.bgDark;
        }
        else if (IMC.dark == false)
        {
            for (int i = 0; i < GameObject.Find("Level (0)").transform.childCount; i++)
            {
                GameObject.Find("Level (0)").transform.GetChild(i).GetComponent<SpriteRenderer>().color = IMC.envLight;

            }
            Camera.main.backgroundColor = IMC.bgLight;
        }
    }
    void Update()
    {
        if (this.transform.position.y >= nextLevelHeight - wallHeight)
        {
            GameObject newWall = Instantiate(level, new Vector3(0, nextLevelHeight, 0), Quaternion.identity, levelsContainer.transform);
            newWall.name = "Level (" + currentLevel + ")";


            if (IMC.dark == true)
            {
                newWall.transform.GetChild(0).GetComponent<SpriteRenderer>().color = IMC.envDark;
                newWall.transform.GetChild(1).GetComponent<SpriteRenderer>().color = IMC.envDark;
                newWall.transform.GetChild(2).GetComponent<SpriteRenderer>().color = IMC.envDark;
            }

            if (IMC.dark == false)
            {
                newWall.transform.GetChild(0).GetComponent<SpriteRenderer>().color = IMC.envLight;
                newWall.transform.GetChild(1).GetComponent<SpriteRenderer>().color = IMC.envLight;
                newWall.transform.GetChild(2).GetComponent<SpriteRenderer>().color = IMC.envLight;
            }


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

            if (IMC.dark == true)
                newObject.GetComponent<SpriteRenderer>().color = IMC.envDark;
            if (IMC.dark == false)
                newObject.GetComponent<SpriteRenderer>().color = IMC.envLight;

            nextLevelHeight = level.transform.GetChild(0).localScale.y * currentLevel;
            if (currentLevel > 2)
            {
                Destroy(levelsContainer.transform.GetChild(0).gameObject);
            }
        }
    }
}
