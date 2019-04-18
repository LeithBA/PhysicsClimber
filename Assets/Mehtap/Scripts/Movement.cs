using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float m_movementSpeed = 100f;
    [SerializeField] float m_jumpSpeed = 10f;


    Rigidbody2D m_myRigidBody;
    
    void Start()
    {

        m_myRigidBody = gameObject.GetComponent<Rigidbody2D>();

        if (m_myRigidBody == null)
        {

            Debug.Log("No RigidBody found in PhysicalMovementController");
        }
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");


        ///creating a direction vector for the force
        Vector2 movementForce = new Vector2();

        movementForce.x = horizontalMovement * m_movementSpeed * Time.deltaTime;
        movementForce.y = verticalMovement * m_movementSpeed * Time.deltaTime;

        ///add y force when jumping
        if (Input.GetButton("Jump")) { movementForce.y = m_jumpSpeed * Time.deltaTime; }

        ///and add tp force as an impulse to the rigid body
        m_myRigidBody.AddForce(movementForce, ForceMode2D.Impulse);
    }
}
