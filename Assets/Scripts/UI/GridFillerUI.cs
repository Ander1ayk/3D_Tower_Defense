using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class GridFillerUI : MonoBehaviour
{
    public GameObject gridItemPrefab;
    public Transform gridParent;
    public TowerData[] towerDataArray;
    public AudioClip upgradeSFX;
    public AudioClip cantUpgradeSFX;

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

            TowerItemUI itemUI = Instantiate(gridItemPrefab, gridParent, false).GetComponent<TowerItemUI>();
            itemUI.Setup(state);
            itemUI.OnUpgradeRequested += HandleUpgrade;

        }
    }
    private void HandleUpgrade(TowerUpgradeState state, TowerItemUI itemUI)
    {
        if (Bank.Instance.Withdraw(state.nextUpgradeCost))
        {
            state.Upgrade();
            itemUI.Refresh(state);
            AudioManager.Instance.PlaySFX(upgradeSFX);
        }
        else
        {
            itemUI.upgradeButton.transform.DOShakePosition(0.5f, 10f);
            AudioManager.Instance.PlaySFX(cantUpgradeSFX);
        }
    }
}
