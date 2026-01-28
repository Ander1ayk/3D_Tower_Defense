using UnityEngine;

public class TowerSlowmo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private TowerData towerData;

    private float timeUntilFire;
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, towerData.targetingRange);
    }
}
