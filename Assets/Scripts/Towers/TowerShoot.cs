using UnityEngine;

public class TowerShoot : Tower
{
    [Header("Shooting References")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private bool canRotate = true;
    private HealthBase baseHealth;
    private void Start()
    {
        baseHealth = FindAnyObjectByType<HealthBase>();
    }
    private void Update()
    {
        if (baseHealth != null && baseHealth.IsDestroyed()) return;
        if (target == null)
        {
            FindTarget();
            return;
        }
        if (canRotate)
            RotateTowardsTarget();
        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / (towerData.bulletsPerSecond + towerData.level * 0.2f))
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }
    private void Shoot()
    {
        Vector3 direction = target.position - firePoint.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation *= Quaternion.Euler(90f, 0f, 0f);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
        if(bullet.TryGetComponent(out Bullet bulletScript))
        {
            bulletScript.SetTarget(target);
            bulletScript.SetDamage(towerData.level);
        }
    }
    private void RotateTowardsTarget()
    {
        Vector3 dir = target.position - towerRotationPoint.position;
        dir.y = 0; 
        Quaternion targetRotation = Quaternion.LookRotation(dir);

        towerRotationPoint.rotation = Quaternion.RotateTowards(
            towerRotationPoint.rotation,
            targetRotation,
            towerData.rotationSpeed * Time.deltaTime
        );
    }
}
