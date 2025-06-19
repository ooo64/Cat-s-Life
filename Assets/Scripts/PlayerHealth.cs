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
    private bool hasFallen = false; // pour �viter d�g�ts r�p�t�s chaque frame

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

            Debug.Log("Le joueur est tomb� !");
            // Optionnel : remonter le joueur pour �viter la mort imm�diate
            // transform.position = new Vector3(0f, 2f, 0f);
        }

        // R�active les d�g�ts de chute si le joueur remonte
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
            // Tu peux recharger la sc�ne ici si tu veux
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