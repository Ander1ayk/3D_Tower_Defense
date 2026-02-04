using UnityEngine;
// Data class to hold the upgrade state of a tower
[System.Serializable]
public class TowerUpgradeState
{
    public TowerData data;
    public int currentLevel;
    public int nextUpgradeCost;

    public TowerUpgradeState(TowerData originalData)
    {
        data = originalData;

        currentLevel = PlayerPrefs.GetInt(data.towerName + "_Level", 1);
        nextUpgradeCost = PlayerPrefs.GetInt(data.towerName + "_UpgradeCost", data.startUpgradeCost);
    }
    public void Upgrade()
    {
        currentLevel++;
        nextUpgradeCost += Mathf.RoundToInt(nextUpgradeCost * 0.5f);
        PlayerPrefs.SetInt(data.towerName + "_Level", currentLevel);
        PlayerPrefs.SetInt(data.towerName + "_UpgradeCost", nextUpgradeCost);
    }
}
