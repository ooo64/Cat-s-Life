using UnityEngine;

public class BouncingRat : MonoBehaviour
{
    public float bounceForce = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
        }
    }
}