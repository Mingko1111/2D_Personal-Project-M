using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public Rigidbody2D playerRb;           // Player¿« Rigidbody2D
    public float moveForce = 30f;
    public float torquePower = 5f;
    public float reboundForce = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mouseWorld - rb.position).normalized;

        rb.AddForce(dir * moveForce);
        float angle = Vector2.SignedAngle(transform.right, dir);
        rb.AddTorque(angle * torquePower);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Ground"))
        {
            Vector2 contact = collision.GetContact(0).point;
            Vector2 normal = (contact - rb.position).normalized;

            Vector2 reaction = -normal * reboundForce;
            playerRb.AddForce(reaction, ForceMode2D.Impulse);
        }
    }
}