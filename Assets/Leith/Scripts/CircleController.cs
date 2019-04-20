using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{

    Rigidbody2D rb2D;
    Collider2D col;
	float colRadius;
    [SerializeField] float torqueAmount, jumpForceAmount;

    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<CircleCollider2D>();
		colRadius = this.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        HorizontalMovementListener();
        VerticalMovementListner();
    }

    private void HorizontalMovementListener()
    {
        if (Input.GetAxis("Horizontal") < 0)
            rb2D.AddTorque(torqueAmount);

        else if (Input.GetAxis("Horizontal") > 0)
            rb2D.AddTorque(-torqueAmount);
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
            rb2D.AddForce(Vector2.up * jumpForceAmount, ForceMode2D.Impulse);
        }
    }
}
