using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 1;
    private bool hasDamaged = false; // pour �viter les multiples d�g�ts

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasDamaged) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Le joueur a perdu une vie !");
                hasDamaged = true;

                // Facultatif : faire dispara�tre le rat apr�s collision
                // Destroy(gameObject);
            }
        }
    }
}
