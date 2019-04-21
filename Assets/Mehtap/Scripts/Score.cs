using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float playerPos;
    float maxPos;
    public Text score;

    LavaVulnerability LV;

    void Start()
    {
        LV = GetComponent<LavaVulnerability>();
    }
    void Update()
    {
        float playerPos = gameObject.transform.position.y;

        if (playerPos > maxPos && LV.dead == false)
        {
            maxPos = playerPos;
        }

        //Mathf.Round -> Not to get 1.4 or sth similar
        score.text = "Score:" + Mathf.Round(maxPos * 10).ToString();
    }
}
