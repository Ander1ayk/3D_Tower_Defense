using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    [Header("Path")]
    public Transform[] pathPoints;
    public Transform startPoint;

    public int currency;

    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        currency = 100;
    }
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }
    public bool SpendCurrency(int amount)
    {
        if (currency >= amount)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough currency!");
            return false;
        }
    }
}
