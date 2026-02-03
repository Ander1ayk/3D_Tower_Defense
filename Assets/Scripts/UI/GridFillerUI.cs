using DG.Tweening;
using UnityEngine;

public class GridFillerUI : MonoBehaviour
{
    public GameObject gridItemPrefab;
    public Transform gridParent;
    public TowerData[] towerDataArray;
    void Start()
    {
        FillGrid();
    }
    void FillGrid()
    {
        foreach (TowerData towerData in towerDataArray)
        {
            towerData.level = PlayerPrefs.GetInt(towerData.towerName + "_Level", 1);
            towerData.startUpgradeCost = PlayerPrefs.GetInt(towerData.towerName + "_UpgradeCost", towerData.startUpgradeCost);

            GameObject gridItem = Instantiate(gridItemPrefab, gridParent);
            TowerItemUI towerItemUI = gridItem.GetComponent<TowerItemUI>();

            if(towerItemUI != null)
            {
                towerItemUI.Setup(towerData);
                towerItemUI.OnUpgradeRequested += HandleUpgrade;
            }
        }
    }
    private void HandleUpgrade(TowerData data, TowerItemUI itemUI)
    {
        if(Bank.Instance.GetTotalFunds() >= data.startUpgradeCost)
        {
            bool success = Bank.Instance.Withdraw(data.startUpgradeCost);
            if (success)
            {
                data.level++;
                data.startUpgradeCost += Mathf.RoundToInt(data.startUpgradeCost * 0.5f);
                PlayerPrefs.SetInt(data.towerName + "_Level", data.level);
                PlayerPrefs.SetInt(data.towerName + "_UpgradeCost", data.startUpgradeCost);
                itemUI.Refresh(data);

            }
            else
            {
                itemUI.upgradeButton.transform.DOShakePosition(0.5f, 10f);
            }
        }
    }
}
