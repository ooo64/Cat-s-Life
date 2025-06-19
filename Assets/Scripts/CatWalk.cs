using UnityEngine;

public class CatWalk: MonoBehaviour
{
    public float speed = 28f;
    private Rigidbody2D rb2d;
    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb2d.MovePosition(rb2d.position + movement * speed * Time.deltaTime);

        // Détection de mouvement
        bool isWalking = movement != Vector2.zero;

        // Mise à jour de l'animation
        animator.SetBool("isWalking", isWalking);
    }
}
