using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/Bullet")]
public class BulletData : ScriptableObject
{
    public float bulletSpeed;
    public int damage;
    public float timeToLive;
}
