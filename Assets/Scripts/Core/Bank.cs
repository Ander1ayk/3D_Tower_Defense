using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank Instance;

    private int totalFunds;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Bank in scene!");
            Instance = null;
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        totalFunds = PlayerPrefs.GetInt("BankFunds", totalFunds);
        ScreenUI.Instance.UpdateBankInfo(totalFunds);
    }
    public int GetTotalFunds() => totalFunds;
    public void Deposit(int amount)
    {
        totalFunds += amount;
        PlayerPrefs.SetInt("BankFunds", totalFunds);
        ScreenUI.Instance.UpdateBankInfo(totalFunds);
    }
    public bool Withdraw(int amount)
    {
        if (totalFunds >= amount)
        {
            totalFunds -= amount;
            PlayerPrefs.SetInt("BankFunds", totalFunds);
            ScreenUI.Instance.UpdateBankInfo(totalFunds);
            return true;
        }
        else
        {
            Debug.Log("Insufficient funds in the bank!");
            return false;
        }
    }
}
