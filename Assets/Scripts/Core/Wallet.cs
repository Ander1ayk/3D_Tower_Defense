using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance; 
    private int currency;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Wallet in scene!");
            return;
        }
        Instance = this;
        currency = 100; // Starting currency
        
    }
    private void Start()
    {
        ScreenUI.Instance.UpdateMatchCoinsInfo(currency);
    }
    public int GetCurrency() => currency;
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        ScreenUI.Instance.UpdateMatchCoinsInfo(currency);
    }
    public bool SpendCurrency(int amount)
    {
        if (currency >= amount)
        {
            currency -= amount;
            ScreenUI.Instance.UpdateMatchCoinsInfo(currency);
            return true;
        }
        else
        {
            Debug.Log("Not enough currency!");
            return false;
        }
    }
}
