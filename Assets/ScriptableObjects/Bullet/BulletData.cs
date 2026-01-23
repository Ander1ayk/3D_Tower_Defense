using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/Bullet")]
public class BulletData : ScriptableObject
{
    public float bulletSpeed;
    public float damage;
    public float timeToLive;
}
