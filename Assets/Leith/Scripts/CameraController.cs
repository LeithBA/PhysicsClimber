using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player01;
    [SerializeField] float trackSpeed, trackSlack;

    Vector3 initialCameraPos;
    private void Start()
    {
        initialCameraPos = transform.position;
    }
    private void Update()
    {
        if (transform.position.y < player01.transform.position.y - trackSlack)
            transform.position = new Vector3(initialCameraPos.x,
                                             Mathf.Lerp(transform.position.y,
                                                        player01.transform.position.y,
                                                        trackSpeed),
                                             initialCameraPos.z);

        else if (transform.position.y > player01.transform.position.y + trackSlack && transform.position.y >= initialCameraPos.y)
            transform.position = new Vector3(initialCameraPos.x,
                                             Mathf.Lerp(transform.position.y,
                                                        player01.transform.position.y,
                                                        trackSpeed),
                                             initialCameraPos.z);
    }
}
