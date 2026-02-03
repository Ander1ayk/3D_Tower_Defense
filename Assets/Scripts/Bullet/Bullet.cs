using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Attributes")]
    [SerializeField] private BulletData bulletData;
    private int damage;

    private Transform target;
    private void Start()
    {
        Destroy(gameObject, bulletData.timeToLive);
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void FixedUpdate()
    {
        if(target == null)
        {
            return;
        }
        Vector3 direction =(target.position - transform.position).normalized;

        rb.linearVelocity = direction * bulletData.bulletSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<Health>(out Health healthComponent))
            {
                healthComponent.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    public int SetDamage(float amount)
    {
        damage = Mathf.RoundToInt(bulletData.damage + amount);
        return damage;
    }
}
