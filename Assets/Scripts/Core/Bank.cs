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
        totalFunds = JsonSave.Instance.currentData.totalFunds;
        ScreenUI.Instance.UpdateBankInfo(totalFunds);
    }
    public int GetTotalFunds() => totalFunds;
    public void Deposit(int amount)
    {
        totalFunds += amount;
        JsonSave.Instance.currentData.totalFunds = totalFunds;
        JsonSave.Instance.SaveGame();
        ScreenUI.Instance.UpdateBankInfo(totalFunds);
    }
    public bool Withdraw(int amount)
    {
        if (totalFunds >= amount)
        {
            totalFunds -= amount;
            JsonSave.Instance.currentData.totalFunds = totalFunds;
            JsonSave.Instance.SaveGame();
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
