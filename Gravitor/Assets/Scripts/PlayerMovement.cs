using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 500f;
    [SerializeField] private float jumpForce = 690f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Space for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime * -rb.gravityScale * -1);
        }

        // Shift for flip
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Flip();
        }

        // A/D for movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed * Time.deltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        // Flip the player
        sr.flipY = !sr.flipY;
        rb.gravityScale *= -1;
    }
}
