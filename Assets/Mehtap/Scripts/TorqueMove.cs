using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueMove : MonoBehaviour
{
    public float torquespeed = 50f;
    [SerializeField] float m_movementSpeed = 100f;
    [SerializeField] float m_jumpSpeed = 10f;
    Collider2D col;
    float colRadius;
    [SerializeField] float torqueAmount, jumpForceAmount;

    Rigidbody2D playerone;


    // Use this for initialization
    void Start()
    {
        playerone = gameObject.GetComponent<Rigidbody2D>();

        if (playerone == null)
        {

            Debug.Log("No RigidBody found in PhysicalMovementController");
        }
    }

    // Because Add Torque uses Physics -> Fixed Update instead update
    /*void FixedUpdate ()
    {
        //AddTorque is used like Rigidbody.AddTorque(vector,ForceMode)

        playerone.AddTorque(torquespeed, ForceMode2D.Force);

    }*/

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");


        Vector2 movementForce = new Vector2();

        movementForce.x = horizontalMovement * m_movementSpeed * Time.deltaTime;
        movementForce.y = verticalMovement * m_movementSpeed * Time.deltaTime;


        playerone.AddTorque(movementForce.x, ForceMode2D.Force);
        playerone.AddTorque(movementForce.y, ForceMode2D.Force);

        Jump();
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            playerone.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    private void VerticalMovementListner()
    {
        Vector3 playerFeet = col.bounds.min + new Vector3(colRadius, -0.01f, 0);

        bool isGrounded = Physics2D.Raycast(playerFeet,
                                            Vector3.down,
                                            0.1f);

        Debug.DrawRay(playerFeet, Vector3.down * 0.1f, Color.yellow);
        Debug.Log(isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            playerone.AddForce(Vector2.up * jumpForceAmount, ForceMode2D.Impulse);
        }
    }
}

