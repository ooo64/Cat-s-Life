using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coinsCount;

    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }
}
