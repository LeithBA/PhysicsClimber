using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpawner : MonoBehaviour
{

    float timer = 0;
    [SerializeField] float initialTimer, lavaPeriod;
    [SerializeField] GameObject lava, lavaContainer;

	Vector3 initialPos;

    void Start()
    {
		initialPos = transform.position;
    }

    void Update()
    {
        if (Time.time > initialTimer)
        {
            timer += Time.deltaTime;
            if (timer >= lavaPeriod)
            {
                timer = 0;
                lavaInit();
            }
        }
    }

    private void lavaInit()
    {
		transform.position = new Vector3(initialPos.x + Random.Range(-0.5f, 0.5f), 
										 transform.position.y, 
										 transform.position.z);

        Instantiate(lava, gameObject.transform.position, Quaternion.identity, lavaContainer.transform);
    }
}
