using UnityEngine;

public class TowerSlowmo : Tower
{
    private void Update()
    {
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
        foreach (Collider col in hitColliders)
        {
            if (col.TryGetComponent<EnemyMovement>(out EnemyMovement em))
            {
                em.ApplySlow(0.5f, towerData.freezeTime);
            }
        }
    }
}
