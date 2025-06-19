using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float fallThreshold = -3; // hauteur de chute minimale
    private bool hasFallen = false; // pour éviter dégâts répétés chaque frame

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    void Update()
    {
        if (!hasFallen && transform.position.y < fallThreshold)
        {
            TakeDamage(1);
            hasFallen = true;

            Debug.Log("Le joueur est tombé !");
            // Optionnel : remonter le joueur pour éviter la mort immédiate
            // transform.position = new Vector3(0f, 2f, 0f);
        }

        // Réactive les dégâts de chute si le joueur remonte
        if (transform.position.y > fallThreshold + 1f)
        {
            hasFallen = false;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHearts();

        if (currentHealth == 0)
        {
            Debug.Log("Le joueur est mort !");
            // Tu peux recharger la scène ici si tu veux
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            hearts[i].enabled = i < maxHealth;
        }
    }
}