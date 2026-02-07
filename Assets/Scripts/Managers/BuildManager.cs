using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    [Header("References")]
    [SerializeField] private TowerData[] towers;
    [SerializeField] private AudioClip buildTower;

    private int selectedTower = 0;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        Instance = this;
    }
    public TowerData GetSelectedTowerPrefab()
    {
        return towers[selectedTower];
    }
    public void SetSelectedTower(int _selectedTower)
    {
        if(_selectedTower < 0 || _selectedTower >= towers.Length)
        {
            return;
        }
        selectedTower = _selectedTower;

        if(ScreenUI.Instance != null)
        {
            ScreenUI.Instance.UpdateInfoCostTower(towers[selectedTower].towerName, towers[selectedTower].costInMatch);
        }
    }
    public void PlayBuildSound()
    {
        AudioManager.Instance.PlaySFX(buildTower, false, 0.9f);
    }
}
