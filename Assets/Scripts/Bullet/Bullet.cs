using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int damage = 1;

    private Transform target;

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

        rb.linearVelocity = direction * bulletSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health healthComponent))
        {
            healthComponent.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
