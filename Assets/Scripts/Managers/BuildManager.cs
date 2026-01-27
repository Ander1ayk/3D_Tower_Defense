using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    [Header("References")]
    [SerializeField] private TowerData[] towers;

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
        selectedTower = _selectedTower;
    }
}
