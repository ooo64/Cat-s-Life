using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannedFishBehavior : MonoBehaviour
{
    public int value = 1;
    private GameObject coinUI;
    private Text coinText;

    void Start()
    {
        // Trouver le GameObject avec le tag CoinAmount (ou FishAmount)
        coinUI = GameObject.FindGameObjectWithTag("CoinAmount"); // Changez en "FishAmount" si nécessaire

        // Vérifier si l'objet existe et récupérer le composant Text
        if (coinUI != null)
        {
            coinText = coinUI.GetComponent<Text>();
            if (coinText == null)
            {
                Debug.LogError("Nothing");
            }
        }
        else
        {
            Debug.LogError("Nothing");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Vérifier si l'objet qui entre en collision a le tag "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Canned fish catch!");

            // Vérifier que les composants UI existent
            if (coinText != null)
            {
                // Convertir le texte actuel en nombre et ajouter la valeur
                int currentCoins;
                if (int.TryParse(coinText.text, out currentCoins))
                {
                    currentCoins += value;
                    coinText.text = currentCoins.ToString();
                }
                else
                {
                    // Si la conversion échoue, initialiser à la valeur de la pièce
                    coinText.text = value.ToString();
                    Debug.LogWarning("Impossible" + value);
                }
            }

            // Détruire l'objet pièce
            Destroy(gameObject);
        }
    }
}