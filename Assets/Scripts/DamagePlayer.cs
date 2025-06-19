using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 1;
    private bool hasDamaged = false; // pour éviter les multiples dégâts

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

                // Facultatif : faire disparaître le rat après collision
                // Destroy(gameObject);
            }
        }
    }
}
