using UnityEngine;
[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Tower")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public float targetingRange;
    public float rotationSpeed;
    public float bulletsPerSecond;
    public float freezeTime;

    public int costInMatch;
    public int startUpgradeCost;

    public GameObject prefab;
}
