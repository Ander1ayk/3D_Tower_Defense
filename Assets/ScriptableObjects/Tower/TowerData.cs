using UnityEngine;
[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Tower")]
public class TowerData : ScriptableObject
{
    public float targetingRange;
    public float rotationSpeed;
    public float bulletsPerSecond;

    public int costInMatch;
    public int startUpgradeCost;
}
