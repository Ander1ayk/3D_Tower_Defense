using UnityEngine;
// Data class to hold the upgrade state of a tower
[System.Serializable]
public class TowerUpgradeState
{
    public TowerData data;
    public int currentLevel;
    public int nextUpgradeCost;

    private TowerSaveEntry saveEntry;
    public TowerUpgradeState(TowerData originalData)
    {
        data = originalData;
        saveEntry = JsonSave.Instance.currentData.towerLevels.Find(e => e.towerName == data.towerName);
        if(saveEntry == null)
        {
            saveEntry = new TowerSaveEntry
            {
                towerName = data.towerName,
                level = 1,
                upgradeCost = data.startUpgradeCost
            };
            JsonSave.Instance.currentData.towerLevels.Add(saveEntry);
            JsonSave.Instance.SaveGame();
        }
        currentLevel = saveEntry.level;
        nextUpgradeCost = saveEntry.upgradeCost;
        
    }
    public void Upgrade()
    {
        currentLevel++;
        nextUpgradeCost += Mathf.RoundToInt(nextUpgradeCost * 0.5f);

        saveEntry.level = currentLevel;
        saveEntry.upgradeCost = nextUpgradeCost;

        JsonSave.Instance.SaveGame();
    }
}
