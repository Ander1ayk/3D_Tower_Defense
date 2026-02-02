using TMPro;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    public static ScreenUI Instance;
    [Header("Screen UI")]
    [SerializeField] private TextMeshProUGUI waveInfo;
    [SerializeField] private TextMeshProUGUI bankInfo;
    [SerializeField] private TextMeshProUGUI matchCoinsInfo;
    [SerializeField] private TextMeshProUGUI InfoCostTower;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one ScreenUI in scene!");
            return;
        }
        Instance = this;
    }

    public void UpdateWaveInfo(int wave)
    {
        waveInfo.text = "Wave: " + wave;
    }
    public void UpdateBankInfo(int bank)
    {
        bankInfo.text = "Bank: " + bank;
    }
    public void UpdateMatchCoinsInfo(int matchCoins)
    {
        matchCoinsInfo.text = "Match Coins: " + matchCoins;
    }
    public void UpdateInfoCostTower(string name, int cost)
    {
        InfoCostTower.text = name + " cost " + cost;
    }
}
