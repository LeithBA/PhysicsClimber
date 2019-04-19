using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//POINTER CONTROLLER
public class PointerController : MonoBehaviour
{
    Vector3 mousePos;
    Rigidbody2D rb2D;
    [SerializeField] GameObject grapple;

    GameObject nextObject;

    [SerializeField] GameObject[] objects;
    [SerializeField, Range(0.01f, 2)] float coolDown = 0.5f;

    bool loaded = false;
    float timer = 0;

    private void Start()
    {
        Cursor.visible = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        MouseInitPos();
        ObjectInit();       

    }
    private void Update()
    {
        PointerUpdatePos();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ObjectRelease();
        }

        if (loaded == false)
        {
            timer += Time.deltaTime;
            if (timer >= coolDown)
            {
                ObjectInit();
                timer = 0;
            }
        }
    }

    //TRANSLATES POINTER TO MOUSE POSITION
    private void MouseInitPos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        gameObject.transform.position = mousePos;
    }

    //USES PHYSICS TO MOVE POINTER TO MOUSE POSITION
    private void PointerUpdatePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        rb2D.MovePosition(mousePos);
    }

    //INSTANTIATES NEXT OBJECT TO PLACE
    private void ObjectInit()
    {
        GameObject randomPick;
        randomPick = objects[Random.Range(0, objects.Length)];

        nextObject = Instantiate(randomPick, grapple.transform.position, Quaternion.identity);
        randomPick.GetComponent<HingeJoint2D>().connectedBody = grapple.GetComponent<Rigidbody2D>();

        loaded = true;
    }

    private void ObjectRelease()
    {
        if (nextObject != null)
        {
            nextObject.GetComponent<HingeJoint2D>().enabled = false;

            loaded = false;
        }
    }
}
