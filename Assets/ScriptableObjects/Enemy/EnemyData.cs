using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/Enemy")]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public float speed;

    public int rewardMatchCoins;
    public int rewardGameCoins;
}
