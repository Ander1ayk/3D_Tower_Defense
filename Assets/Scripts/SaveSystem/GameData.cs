using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int totalFunds;
    public List<TowerSaveEntry> towerLevels = new List<TowerSaveEntry>();
}
[System.Serializable]
public class TowerSaveEntry
{
    public string towerName;
    public int level;
    public int upgradeCost;
}
