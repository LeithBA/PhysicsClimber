using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{

    Rigidbody2D rb2D;
    Collider2D col;
    float colRadius;
    [SerializeField] float torqueAmount, jumpVerticalForceAmount, jumpHorizontalForceAmount;

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
                                            0.2f);

        Debug.DrawRay(playerFeet, Vector3.down * 0.2f, Color.yellow);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb2D.AddForce(Vector2.up * jumpVerticalForceAmount, ForceMode2D.Impulse);

            if (Input.GetAxis("Horizontal") < 0)
                rb2D.AddForce(Vector2.left * jumpHorizontalForceAmount, ForceMode2D.Impulse);

            else if (Input.GetAxis("Horizontal") > 0)
                rb2D.AddForce(Vector2.right * jumpHorizontalForceAmount, ForceMode2D.Impulse);
        }
    }
}
