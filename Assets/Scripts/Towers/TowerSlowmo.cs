using UnityEngine;

public class TowerSlowmo : Tower
{
    private HealthBase baseHealth;
    private void Start()
    {
        baseHealth = FindAnyObjectByType<HealthBase>();
    }
    private void Update()
    {
        if (baseHealth != null && baseHealth.IsDestroyed()) return;
        timeUntilFire += Time.deltaTime;

       if (timeUntilFire >= 1f / towerData.bulletsPerSecond)
       {
            FreezeEnemies();
            timeUntilFire = 0f;
       }
    }
    private void FreezeEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, towerData.targetingRange, enemyMask);
        float currentFreezeTime = towerData.freezeTime + (currentLevel * 0.1f);
        foreach (Collider col in hitColliders)
        {
            if (col.TryGetComponent<EnemyMovement>(out EnemyMovement em))
            {
                em.ApplySlow(0.5f, currentFreezeTime);
            }
        }
    }
}
