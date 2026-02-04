using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class GridFillerUI : MonoBehaviour
{
    public GameObject gridItemPrefab;
    public Transform gridParent;
    public TowerData[] towerDataArray;

    private List<TowerUpgradeState> towerStates = new List<TowerUpgradeState>();
    
    void Start()
    {
        FillGrid();
    }
    void FillGrid()
    {
        foreach (TowerData soData in towerDataArray)
        {
            TowerUpgradeState state = new TowerUpgradeState(soData);
            towerStates.Add(state);

            TowerItemUI itemUI = Instantiate(gridItemPrefab, gridParent).GetComponent<TowerItemUI>();
            itemUI.Setup(state);
            itemUI.OnUpgradeRequested += HandleUpgrade;

        }
    }
    private void HandleUpgrade(TowerUpgradeState state, TowerItemUI itemUI)
    {
        if(Bank.Instance.GetTotalFunds() >= state.nextUpgradeCost)
        {
            bool success = Bank.Instance.Withdraw(state.nextUpgradeCost);
            if (success)
            {
                state.Upgrade();
                itemUI.Refresh(state);

            }
            else
            {
                itemUI.upgradeButton.transform.DOShakePosition(0.5f, 10f);
            }
        }
    }
}
